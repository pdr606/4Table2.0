import { StatusMap } from "elysia";
import { db } from "../../database";
import { ResponseError } from "../../utils/ResponseError";
import { LoginUserDTO } from "./dtos/login-user.dto";
import { RegisterUserDTO } from "./dtos/register-user.dto";

export const authService = {
  async login(data: LoginUserDTO) {
    const userWithEmail = await db
      .selectFrom("users")
      .select(["email", "password", "id"])
      .where("email", "=", data.email)
      .executeTakeFirst();

    if (!userWithEmail) {
      throw new ResponseError(
        StatusMap.Unauthorized,
        "Invalid email or password"
      );
    }

    if (!Bun.password.verifySync(data.password, userWithEmail.password)) {
      throw new ResponseError(
        StatusMap.Unauthorized,
        "Invalid email or password"
      );
    }

    return {
      id: userWithEmail.id,
      email: userWithEmail.email,
    };
  },

  async register(data: RegisterUserDTO) {
    const userWithEmail = await db
      .selectFrom("users")
      .select(["email"])
      .where("email", "=", data.email)
      .executeTakeFirst();

    if (userWithEmail) {
      throw new ResponseError(StatusMap.Conflict, "Email already exists");
    }

    const user = await db
      .insertInto("users")
      .values({
        email: data.email,
        password: Bun.password.hashSync(data.password),
        name: data.name,
      })
      .returning(["id", "email"])
      .executeTakeFirst();

    if (!user) {
      return new ResponseError(
        StatusMap["Unprocessable Content"],
        "Failed to create user"
      );
    }

    return {
      id: user.id,
      email: user.email,
    };
  },
};

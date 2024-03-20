import { StatusMap } from "elysia";
import { db } from "../../database";
import { CreateUserSchema } from "../../schemas/user.schema";
import { ResponseError } from "../../utils/ResponseError";

type CreateUserDTO = (typeof CreateUserSchema)["static"];

export const userService = {
  async createUser(data: CreateUserDTO) {
    const userWithEmail = await db
      .selectFrom("users")
      .select("id")
      .where("email", "=", data.email)
      .executeTakeFirst();

    if (userWithEmail) {
      return new ResponseError(
        StatusMap["Bad Request"],
        "Email already in use"
      );
    }

    return await db
      .insertInto("users")
      .values({
        email: data.email,
        password: Bun.password.hashSync(data.password),
        name: data.name,
      })
      .returning(["id", "email"])
      .executeTakeFirst();
  },
};

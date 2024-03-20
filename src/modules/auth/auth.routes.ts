import Elysia, { t } from "elysia";
import { jwtConfig } from "../../config/jwt";
import { ResponseError } from "../../utils/ResponseError";
import { authService } from "./auth.service";

export const authRoutes = new Elysia({
  prefix: "/auth",
  name: "Auth Routes",
})
  .use(jwtConfig)
  .error({
    ResponseError,
  });

authRoutes.get(
  "/login",
  async ({ body, jwt }) => {
    const serviceReturn = await authService.login(body);

    if (serviceReturn instanceof ResponseError) {
      throw serviceReturn;
    }

    const token = jwt.sign({
      sub: serviceReturn.id.toString(),
    });

    return token;
  },
  {
    body: t.Object({
      email: t.String({
        format: "email",
      }),
      password: t.String({ minLength: 8, maxLength: 32 }),
    }),
    detail: {
      tags: ["Auth"],
      description: "Login to the application",
    },
  }
);

authRoutes.post(
  "/register",
  ({ body, jwt }) => {
    const serviceReturn = authService.register(body);

    if (serviceReturn instanceof ResponseError) {
      throw serviceReturn;
    }

    return serviceReturn;
  },
  {
    body: t.Object({
      email: t.String({
        format: "email",
      }),
      name: t.String({ minLength: 2, maxLength: 32 }),
      password: t.String({ minLength: 8, maxLength: 32 }),
    }),
    detail: {
      tags: ["Auth"],
      description: "Register a new user",
    },
  }
);

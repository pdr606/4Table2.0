import Elysia from "elysia";
import { db } from "../../database";

export const userRoutes = new Elysia({
  prefix: "/users",
  name: "User Routes",
});

userRoutes.get(
  "/",
  async () => {
    return await db
      .selectFrom("users")
      .select(["id", "email", "role"])
      .execute();
  },
  {
    detail: {
      tags: ["Users"],
    },
  }
);

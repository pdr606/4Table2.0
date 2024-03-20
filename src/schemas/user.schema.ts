import { t } from "elysia";

export const CreateUserSchema = t.Object({
  email: t.String({
    format: "email",
  }),
  password: t.String({ minLength: 8, maxLength: 32 }),
  name: t.String({ minLength: 2, maxLength: 32 }),
});

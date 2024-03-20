import jwt from "@elysiajs/jwt";

export const jwtConfig = jwt({
  name: "jwt",
  secret: "supersecret",
});

import { Elysia } from "elysia";

import { swagger } from "@elysiajs/swagger";
import { userRoutes } from "./modules/user/user.routes";
import { authRoutes } from "./modules/auth/auth.routes";
import { productRoutes } from "./modules/products/products.routes";
import { categoryRoutes } from "./modules/category/category.routes";
import { tableRoutes } from "./modules/table/table.routes";
import { orderRoutes } from "./modules/order/order.routes";

const app = new Elysia()
  .use(userRoutes)
  .use(authRoutes)
  .use(productRoutes)
  .use(categoryRoutes)
  .use(tableRoutes)
  .use(orderRoutes)
  .use(swagger())
  .listen(3000);

console.log(
  `🦊 Elysia is running at ${app.server?.hostname}:${app.server?.port}`
);

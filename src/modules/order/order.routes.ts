import Elysia, { StatusMap, t } from "elysia";
import { orderService } from "./order.service";
import { ResponseError } from "../../utils/ResponseError";
import { OrderStatus } from "../../database/enums";

export const orderRoutes = new Elysia({
  prefix: "/orders",
  name: "Orders",
}).error({
  ResponseError,
});

orderRoutes.get(
  "/",
  async () => {
    return await orderService.getAllOrders();
  },
  {
    detail: {
      tags: ["Orders"],
    },
  }
);

orderRoutes.post(
  "/",
  async ({ body }) => {
    const { table_id, user_id, status } = body;

    if (isNaN(Number(table_id)) || isNaN(Number(user_id))) {
      throw new ResponseError(StatusMap["Bad Request"], "Invalid input");
    }

    const newOrder = await orderService.createOrder({
      status,
      table_id: Number(table_id),
      user_id: Number(user_id),
    });

    if (newOrder instanceof ResponseError) {
      throw newOrder;
    }

    return newOrder;
  },
  {
    detail: {
      tags: ["Orders"],
    },
    body: t.Object({
      table_id: t.String({
        minLength: 1,
      }),
      user_id: t.String({
        minLength: 1,
      }),
      status: t.Enum(OrderStatus),
    }),
  }
);

import { StatusMap } from "elysia";
import { db } from "../../database";
import { OrderStatus } from "../../database/enums";
import { ResponseError } from "../../utils/ResponseError";
import { CreateOrderDTO } from "./dtos/create-order.dto";

export const orderService = {
  async getAllOrders() {
    return await db.selectFrom("orders").selectAll().execute();
  },

  async createOrder(data: CreateOrderDTO) {
    const createdOrder = await db
      .insertInto("orders")
      .values(data)
      .returningAll()
      .executeTakeFirst();

    if (!createdOrder) {
      return new ResponseError(
        StatusMap["Internal Server Error"],
        "Failed to create order"
      );
    }

    return createdOrder;
  },
};

import { OrderStatus } from "../../../database/enums";

export type CreateOrderDTO = {
  table_id: number;
  user_id: number;
  status: OrderStatus;
};

import type { ColumnType } from "kysely";
export type Generated<T> = T extends ColumnType<infer S, infer I, infer U>
  ? ColumnType<S, I | undefined, U>
  : ColumnType<T, T | undefined, T>;
export type Timestamp = ColumnType<Date, Date | string, Date | string>;

import type { OrderStatus, Role } from "./enums";

export type Order = {
    id: Generated<number>;
    table_id: number;
    user_id: number;
    status: Generated<OrderStatus>;
    created_at: Generated<Timestamp>;
    updated_at: Generated<Timestamp>;
};
export type OrderItem = {
    id: Generated<number>;
    orderId: number;
    quantity: number;
    product_id: number;
    created_at: Generated<Timestamp>;
    updated_at: Generated<Timestamp>;
};
export type Product = {
    id: Generated<number>;
    name: string;
    price: number;
    ingredients: string[];
    category_id: number;
    created_at: Generated<Timestamp>;
    updated_at: Generated<Timestamp>;
};
export type ProductCategory = {
    id: Generated<number>;
    name: string;
};
export type Table = {
    id: Generated<number>;
    number: number;
    created_at: Generated<Timestamp>;
    updated_at: Generated<Timestamp>;
};
export type User = {
    id: Generated<number>;
    email: string;
    name: string;
    password: string;
    role: Role | null;
    created_at: Generated<Timestamp>;
    updated_at: Generated<Timestamp>;
};
export type DB = {
    order_items: OrderItem;
    orders: Order;
    product_categories: ProductCategory;
    products: Product;
    tables: Table;
    users: User;
};

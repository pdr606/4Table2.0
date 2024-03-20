export const OrderStatus = {
    PENDING: "PENDING",
    IN_PROGRESS: "IN_PROGRESS",
    DONE: "DONE",
    CANCELLED: "CANCELLED"
} as const;
export type OrderStatus = (typeof OrderStatus)[keyof typeof OrderStatus];
export const Role = {
    ADMIN: "ADMIN",
    WAITER: "WAITER"
} as const;
export type Role = (typeof Role)[keyof typeof Role];

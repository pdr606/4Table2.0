/*
  Warnings:

  - You are about to drop the column `tableId` on the `orders` table. All the data in the column will be lost.
  - Added the required column `table_id` to the `orders` table without a default value. This is not possible if the table is not empty.

*/
-- DropForeignKey
ALTER TABLE "orders" DROP CONSTRAINT "orders_tableId_fkey";

-- DropIndex
DROP INDEX "orders_id_tableId_user_id_idx";

-- AlterTable
ALTER TABLE "orders" DROP COLUMN "tableId",
ADD COLUMN     "table_id" INTEGER NOT NULL,
ALTER COLUMN "status" SET DEFAULT 'PENDING';

-- CreateIndex
CREATE INDEX "orders_id_table_id_user_id_idx" ON "orders"("id", "table_id", "user_id");

-- AddForeignKey
ALTER TABLE "orders" ADD CONSTRAINT "orders_table_id_fkey" FOREIGN KEY ("table_id") REFERENCES "tables"("id") ON DELETE RESTRICT ON UPDATE CASCADE;

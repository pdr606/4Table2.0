FROM oven/bun:1.0.33-alpine

COPY bun.lockb . 
COPY package.json . 
COPY prisma .

RUN bun install --freeze-lockfile
RUN bun db:generate

COPY src ./src 

EXPOSE 3000

CMD ["bun", "src/index.ts"]
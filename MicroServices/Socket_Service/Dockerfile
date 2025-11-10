# Etapa de compilación
FROM node:20.11.1-alpine3.19 AS builder

WORKDIR /app

# Copiar los archivos de definición de dependencias y instalar las dependencias de Node.js
COPY package*.json ./
RUN npm install -f

# Copiar el resto de los archivos del proyecto
COPY . .

# Compilar el TypeScript a JavaScript
RUN npx tsc

# Etapa de ejecución
FROM node:20.11.1-alpine3.19

WORKDIR /app

# Copiar solo los archivos necesarios para la ejecución de Node.js
COPY --from=builder /app/build ./build
# Copiar los archivos de Node.js que se necesitan para la ejecución
COPY --from=builder /app/node_modules ./node_modules
COPY --from=builder /app/package*.json ./

# Comando para iniciar la aplicación
CMD ["node", "./build/app.js"]

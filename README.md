# 📦 ApiHexSyaca

Este proyecto es una API desarrollada en **.NET 8** utilizando el **patrón de arquitectura hexagonal** (también conocido como Ports and Adapters). La principal razón para usar este patrón es la **segregación de responsabilidades**, lo cual permite que la lógica de negocio se mantenga completamente **aislada** del resto de las capas, facilitando el mantenimiento, escalabilidad y pruebas.

---

## 🧩 Características principales

- ✅ **Separación clara de responsabilidades**: La lógica de negocio permanece desacoplada e independiente del resto de la infraestructura.
- ✅ **Inyección de dependencias modular**: Cada capa tiene su propia clase de configuración para registrar dependencias, evitando la saturación del `Program.cs`.
- ✅ **Sin dependencias innecesarias**: Por ejemplo, el proyecto de dominio no referencia bibliotecas externas, asegurando su aislamiento.
- ✅ **Uso de MediatR (patrón mediador)**: Cada caso de uso está separado como un `Command` o `Query`, siguiendo el principio de responsabilidad única.
- ✅ **Minimal API**: Se utiliza para simplificar el código y reducir la sobrecarga, ideal para APIs pequeñas o medianas.

---

## 🚀 Estructura de controladores

- ### `ApiParametros`
  Controlador que expone los endpoints necesarios para consultar las listas requeridas al crear un pedido, como:
  - Clientes
  - Estados
  - Productos

- ### `PedidosEndpoints`
  Controlador que expone el endpoint para crear un nuevo pedido, incluyendo la lógica para:
  - Calcular el valor total
  - Determinar la prioridad
  - Registrar cabecera y detalles del pedido

---

## 🛠️ Tecnologías utilizadas

- .NET 8
- C#
- Entity Framework Core
- SQL Server
- MediatR
- Minimal APIs
- Arquitectura Hexagonal (Ports and Adapters)

---

## 📁 Organización de carpetas

```plaintext
├── Api/                        → Punto de entrada (Minimal API, controladores)
├── Application/               → Casos de uso, DTOs, comandos y consultas
├── Domain/                    → Entidades y contratos (repositorios)
├── Infrastructure/           → Adaptadores que implementan los puertos (repositorios)
├── Infraestructure.Data/     → DbContext y configuración EF Core
r
Copiar código

# Microservicios - Apunte de Clase Backend

## ¿Qué son los Microservicios?

Los microservicios son un **patrón de arquitectura** que estructura una aplicación como una colección de servicios pequeños, independientes y débilmente acoplados. Cada servicio se ejecuta en su propio proceso y se comunica a través de APIs bien definidas.

### Características Principales

- **Independencia**: Cada microservicio puede desarrollarse, desplegarse y escalarse de forma independiente
- **Responsabilidad única**: Cada servicio tiene una responsabilidad específica del negocio
- **Comunicación por red**: Los servicios se comunican a través de protocolos de red (HTTP/REST, messaging)
- **Descentralización**: Cada servicio puede tener su propia base de datos y tecnología

---

## Comunicación entre Microservicios

### APIs REST como Mecanismo Principal

Los microservicios utilizan **Web APIs** para comunicarse entre sí, aplicando los conceptos que vimos:

#### Métodos HTTP en Microservicios
- **GET**: Consultar datos de otros servicios
- **POST**: Crear recursos en servicios remotos
- **PUT**: Actualizar recursos en otros microservicios
- **DELETE**: Eliminar recursos de servicios externos

#### Endpoints Distribuidos
```
Servicio de Usuarios:     /api/users/{id}
Servicio de Productos:    /api/products/{id}
Servicio de Pedidos:      /api/orders/{id}
```

#### Status Codes Importantes
- **200 OK**: Comunicación exitosa entre servicios
- **404 Not Found**: Servicio o recurso no disponible
- **500 Internal Server Error**: Falla en el servicio remoto
- **503 Service Unavailable**: Servicio temporalmente no disponible

---

## Conexión con Próximas Clases

### Inyección de Dependencias (próximo tema)
Los microservicios utilizan patrones de **inyección de dependencias** para manejar las comunicaciones entre servicios. En lugar de crear conexiones directas, se inyectan **clientes HTTP** que facilitan la comunicación entre microservicios de forma desacoplada.

*Este concepto se expandirá en las próximas clases cuando veamos cómo gestionar dependencias en aplicaciones distribuidas.*

### ORM - Object Relational Mapping (próximo tema)  
En arquitecturas de microservicios, cada servicio maneja su **propia base de datos** usando ORMs. Esto significa que cada microservicio tendrá su propio contexto de base de datos, totalmente independiente de los demás.

*Veremos cómo Entity Framework y LINQ nos permiten trabajar con estas bases de datos distribuidas sin escribir SQL directamente.*

---

## Ventajas de los Microservicios

### 1. **Escalabilidad Independiente**
- Cada servicio puede escalarse según su demanda específica
- Optimización de recursos por servicio

### 2. **Tecnologías Diversas**
- Cada equipo puede elegir la mejor tecnología para su dominio
- Migración gradual de tecnologías

### 3. **Desarrollo Paralelo**
- Múltiples equipos pueden trabajar simultáneamente
- Menor dependencia entre equipos

### 4. **Resiliencia**
- Si un servicio falla, los otros pueden continuar funcionando
- Aislamiento de errores

---

## Desafíos de los Microservicios

### 1. **Complejidad de Red**
- Latencia de red entre servicios
- Manejo de timeouts y reintentos

### 2. **Consistencia de Datos**
- No hay transacciones ACID entre servicios
- Necesidad de **eventual consistency**

### 3. **Monitoreo Distribuido**
- Logs distribuidos entre múltiples servicios
- Trazabilidad de requests entre servicios

### 4. **Testing Complejo**
- Pruebas de integración entre servicios
- Necesidad de service mocks

---

## Patrones Importantes

### 1. **API Gateway**
- Punto único de entrada para clientes
- Routing a microservicios internos
- Autenticación y autorización centralizada

### 2. **Service Discovery**
- Registro automático de servicios
- Localización dinámica de servicios

### 3. **Circuit Breaker**
- Prevención de cascadas de fallos
- Respuesta rápida cuando un servicio está caído

### 4. **Event-Driven Architecture**
- Comunicación asíncrona vía eventos
- Desacoplamiento temporal entre servicios

---

## Herramientas y Tecnologías

### Contenedorización
- **Docker**: Empaquetado de microservicios
- **Kubernetes**: Orquestación de contenedores

### Comunicación
- **REST APIs**: Comunicación síncrona
- **Message Queues**: Comunicación asíncrona (RabbitMQ, Apache Kafka)

### Monitoreo
- **Application Insights**: Monitoreo de aplicaciones
- **Prometheus + Grafana**: Métricas y dashboards

---

## Ejemplo Práctico: E-commerce

```
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│   API Gateway   │    │   Web Client    │    │  Mobile App     │
└─────────┬───────┘    └─────────┬───────┘    └─────────┬───────┘
          │                      │                      │
          └──────────────────────┼──────────────────────┘
                                 │
          ┌─────────────────────────────────────────────┐
          │                Load Balancer                │
          └─────────┬───────────────────────┬───────────┘
                    │                       │
    ┌───────────────▼─────────┐   ┌─────────▼─────────────┐
    │  Usuario Service        │   │  Producto Service     │
    │  - POST /api/users      │   │  - GET /api/products  │
    │  - GET /api/users/{id}  │   │  - PUT /api/products  │
    └─────────┬───────────────┘   └─────────┬─────────────┘
              │                             │
    ┌─────────▼─────────┐         ┌─────────▼─────────┐
    │   BD_Usuarios     │         │   BD_Productos    │
    └───────────────────┘         └───────────────────┘
                    │                       │
            ┌───────▼─────────────────────────▼───────┐
            │           Pedido Service                │
            │  - POST /api/orders                     │
            │  - GET /api/orders/{id}                 │
            └─────────┬───────────────────────────────┘
                      │
            ┌─────────▼─────────┐
            │    BD_Pedidos     │
            └───────────────────┘
```

---

## Conclusión

Los microservicios representan una evolución natural de las arquitecturas monolíticas, aprovechando conceptos como **APIs REST**, **inyección de dependencias** y **ORMs** que ya conocemos, pero aplicándolos en un contexto distribuido. 

**Cuándo usar microservicios:**
- Aplicaciones grandes y complejas
- Equipos múltiples trabajando en paralelo
- Necesidad de escalabilidad independiente
- Dominios de negocio claramente separados

**Cuándo NO usar microservicios:**
- Aplicaciones pequeñas o simples
- Equipos pequeños (< 10 personas)
- Poca experiencia con sistemas distribuidos
- Requerimientos de consistencia estricta
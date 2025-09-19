# Angular - Introducción, Componentes e Interpolación

## ¿Qué es Angular?

Angular es un **framework para construir aplicaciones web modernas** que utiliza **TypeScript** como lenguaje principal.

### Ventajas principales:
- **Componentes reutilizables**: Crear una vez, usar múltiples veces
- **Binding de datos**: Sincronización automática entre modelo y vista  
- **Herramientas integradas**: Para trabajar con formularios, servicios y más
- **Actualizaciones regulares**: Angular se actualiza cada 6 meses con nuevas versiones y mejoras

---

## Componentes

### ¿Qué es un Componente?

Un componente es una **parte independiente de la interfaz de usuario** que encapsula funcionalidad específica.

### Estructura de un componente:

```
mi-componente/
├── mi-componente.component.html    # HTML: Define la vista
├── mi-componente.component.css     # CSS: Define los estilos  
├── mi-componente.component.ts      # TS: Define la lógica
└── mi-componente.component.spec.ts # SPEC: Unit tests
```

### Ejemplo práctico de componente:

**header.component.ts**
```typescript
import { Component } from '@angular/core';

@Component({
  selector: 'app-header',  // Selector para usar el componente
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  titulo = 'Mi Aplicación';
  usuario = 'Juan Pérez';
}
```

**header.component.html**
```html
<header>
  <h1>{{ titulo }}</h1>
  <nav>
    <ul>
      <li><a href="#inicio">Inicio</a></li>
      <li><a href="#productos">Productos</a></li>
      <li><a href="#contacto">Contacto</a></li>
    </ul>
  </nav>
  <div class="usuario">{{ usuario }}</div>
</header>
```

### Usar el componente en otro template:

```html
<app-header></app-header>
<main>
  <!-- Contenido principal -->
</main>
```

---

## Interpolación y Binding

### ¿Qué es la Interpolación?

La interpolación permite **mostrar datos dinámicos en la vista** usando la sintaxis `{{ variable }}`.

**Sintaxis:** `{{ variable }}`

Muestra el valor de una propiedad definida en el archivo TypeScript.

### Ejemplos prácticos:

**producto.component.ts**
```typescript
export class ProductoComponent {
  nombre = 'Laptop Gaming';
  precio = 1299.99;
  stock = 5;
  disponible = true;
  categoria = 'Electrónicos';
  
  calcularDescuento(): number {
    return this.precio * 0.1;
  }
  
  getPrecioFinal(): number {
    return this.precio - this.calcularDescuento();
  }
}
```

**producto.component.html**
```html
<div class="producto">
  <!-- Interpolación básica -->
  <h2>{{ nombre }}</h2>
  <p>Categoría: {{ categoria }}</p>
  <p>Precio: ${{ precio }}</p>
  <p>Stock disponible: {{ stock }} unidades</p>
  
  <!-- Interpolación con expresiones -->
  <p>Estado: {{ disponible ? 'Disponible' : 'Agotado' }}</p>
  <p>IVA (21%): ${{ precio * 0.21 }}</p>
  
  <!-- Interpolación con métodos -->
  <p>Descuento: ${{ calcularDescuento() }}</p>
  <p>Precio final: ${{ getPrecioFinal() }}</p>
  
  <!-- Operaciones matemáticas -->
  <p>Precio por 3 unidades: ${{ precio * 3 }}</p>
</div>
```

### Más ejemplos de interpolación:

**usuario.component.ts**
```typescript
export class UsuarioComponent {
  nombre = 'María';
  apellido = 'González';
  edad = 30;
  hobbies = ['Lectura', 'Cine', 'Deportes'];
  fechaRegistro = new Date();
  
  getNombreCompleto(): string {
    return `${this.nombre} ${this.apellido}`;
  }
}
```

**usuario.component.html**
```html
<div class="perfil">
  <!-- String concatenation -->
  <h1>Perfil de {{ nombre }} {{ apellido }}</h1>
  
  <!-- Llamada a método -->
  <h2>{{ getNombreCompleto() }}</h2>
  
  <!-- Operaciones -->
  <p>Edad: {{ edad }} años</p>
  <p>Mayor de edad: {{ edad >= 18 ? 'Sí' : 'No' }}</p>
  
  <!-- Arrays -->
  <p>Hobbies: {{ hobbies.length }}</p>
  <p>Primer hobby: {{ hobbies[0] }}</p>
  <p>Todos los hobbies: {{ hobbies.join(', ') }}</p>
  
  <!-- Fechas con pipe -->
  <p>Registrado el: {{ fechaRegistro | date:'short' }}</p>
</div>
```

---

## Comandos Angular CLI Esenciales

```bash
# Crear nuevo proyecto
ng new mi-proyecto

# Servir la aplicación (desarrollo)
ng serve

# Generar componente
ng generate component mi-componente
# o abreviado:
ng g c mi-componente

# Construir para producción  
ng build

# Ejecutar tests
ng test
```

---

## Documentación Oficial

- **Angular.io**: [https://angular.io/](https://angular.io/)
- **Angular CLI**: [https://cli.angular.io/](https://cli.angular.io/)
- **Guías y tutoriales**: [https://angular.io/tutorial](https://angular.io/tutorial)
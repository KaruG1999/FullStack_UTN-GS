# Directivas Estructurales y Comunicación entre Componentes

## Directivas Estructurales

Las directivas estructurales **modifican la estructura del DOM** agregando, eliminando o manipulando elementos.

### *ngIf - Condicionales

**Sintaxis:** `*ngIf="condicion"`

Muestra u oculta un elemento basado en una condición.

#### Ejemplos prácticos:

**usuario.component.ts**
```typescript
export class UsuarioComponent {
  usuario = {
    nombre: 'Ana López',
    edad: 25,
    activo: true,
    rol: 'admin'
  };
  
  mostrarDetalles = false;
  cargando = false;
}
```

**usuario.component.html**
```html
<div class="usuario">
  <!-- ngIf básico -->
  <h2 *ngIf="usuario.activo">{{ usuario.nombre }}</h2>
  <p *ngIf="!usuario.activo">Usuario inactivo</p>
  
  <!-- ngIf con else -->
  <div *ngIf="usuario.edad >= 18; else menorEdad">
    <p>Usuario mayor de edad</p>
  </div>
  <ng-template #menorEdad>
    <p>Usuario menor de edad</p>
  </ng-template>
  
  <!-- ngIf con múltiples condiciones -->
  <button *ngIf="usuario.activo && usuario.rol === 'admin'">
    Panel de Administración
  </button>
  
  <!-- Mostrar/ocultar secciones -->
  <button (click)="mostrarDetalles = !mostrarDetalles">
    {{ mostrarDetalles ? 'Ocultar' : 'Mostrar' }} Detalles
  </button>
  
  <div *ngIf="mostrarDetalles" class="detalles">
    <p>Edad: {{ usuario.edad }}</p>
    <p>Rol: {{ usuario.rol }}</p>
  </div>
  
  <!-- Loading spinner -->
  <div *ngIf="cargando" class="spinner">Cargando...</div>
</div>
```

### *ngFor - Bucles/Iteraciones

**Sintaxis:** `*ngFor="let item of lista"`

Itera sobre una lista y genera un elemento por cada ítem.

#### Ejemplos prácticos:

**productos.component.ts**
```typescript
export class ProductosComponent {
  productos = [
    { id: 1, nombre: 'Laptop', precio: 999, categoria: 'Electrónicos' },
    { id: 2, nombre: 'Mouse', precio: 25, categoria: 'Accesorios' },
    { id: 3, nombre: 'Teclado', precio: 75, categoria: 'Accesorios' },
    { id: 4, nombre: 'Monitor', precio: 300, categoria: 'Electrónicos' }
  ];
  
  usuarios = [
    { nombre: 'Juan', email: 'juan@email.com', activo: true },
    { nombre: 'María', email: 'maria@email.com', activo: false },
    { nombre: 'Carlos', email: 'carlos@email.com', activo: true }
  ];
  
  numeros = [1, 2, 3, 4, 5];
}
```

**productos.component.html**
```html
<div class="productos">
  <!-- ngFor básico -->
  <div *ngFor="let producto of productos" class="producto-card">
    <h3>{{ producto.nombre }}</h3>
    <p>Precio: ${{ producto.precio }}</p>
    <p>Categoría: {{ producto.categoria }}</p>
  </div>
  
  <!-- ngFor con índice -->
  <ul>
    <li *ngFor="let usuario of usuarios; let i = index">
      {{ i + 1 }}. {{ usuario.nombre }} - {{ usuario.email }}
      <span *ngIf="usuario.activo" class="activo">✓</span>
    </li>
  </ul>
  
  <!-- ngFor con trackBy para mejor performance -->
  <div *ngFor="let producto of productos; trackBy: trackByProductoId" 
       class="producto">
    <p>{{ producto.nombre }}</p>
  </div>
  
  <!-- ngFor con propiedades adicionales -->
  <div *ngFor="let numero of numeros; let primero = first; let ultimo = last; let par = even">
    <span [class.first]="primero" 
          [class.last]="ultimo" 
          [class.even]="par">
      {{ numero }}
    </span>
  </div>
</div>
```

**productos.component.ts** (método trackBy):
```typescript
trackByProductoId(index: number, producto: any): number {
  return producto.id;
}
```

---

## Comunicación entre Componentes

### Decoradores @Input y @Output

Un patrón común en Angular es **compartir datos entre un componente padre y uno o más componentes hijos**.

---

## Decorador @Input

**@Input**: Permite **enviar datos desde un componente padre a un hijo**.

### 1) Configuración del componente hijo:

**hijo.component.ts**
```typescript
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-producto-card',
  templateUrl: './producto-card.component.html',
  styleUrls: ['./producto-card.component.css']
})
export class ProductoCardComponent {
  @Input() producto: any;
  @Input() mostrarDescuento: boolean = false;
  @Input() descuento: number = 0;
  
  calcularPrecioFinal(): number {
    if (this.mostrarDescuento && this.descuento > 0) {
      return this.producto.precio - (this.producto.precio * this.descuento);
    }
    return this.producto.precio;
  }
}
```

**producto-card.component.html**
```html
<div class="card">
  <h3>{{ producto.nombre }}</h3>
  <p>Precio: ${{ producto.precio }}</p>
  <p *ngIf="mostrarDescuento">
    Precio con descuento: ${{ calcularPrecioFinal() }}
  </p>
  <p>Categoría: {{ producto.categoria }}</p>
</div>
```

### 2) Configuración del componente padre:

**padre.component.ts**
```typescript
export class PadreComponent {
  productos = [
    { id: 1, nombre: 'Laptop', precio: 999, categoria: 'Electrónicos' },
    { id: 2, nombre: 'Mouse', precio: 25, categoria: 'Accesorios' }
  ];
  
  aplicarDescuento = true;
  porcentajeDescuento = 0.15; // 15%
}
```

**padre.component.html**
```html
<div class="catalogo">
  <app-producto-card 
    *ngFor="let prod of productos"
    [producto]="prod"
    [mostrarDescuento]="aplicarDescuento"
    [descuento]="porcentajeDescuento">
  </app-producto-card>
</div>
```

---

## Decorador @Output

**@Output**: Permite **enviar datos desde un componente hijo a un padre**.

### 1) Configuración del componente hijo:

**contador.component.ts**
```typescript
import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-contador',
  templateUrl: './contador.component.html',
  styleUrls: ['./contador.component.css']
})
export class ContadorComponent {
  contador = 0;
  
  // Definir eventos de salida
  @Output() contadorCambio = new EventEmitter<number>();
  @Output() valorMaximo = new EventEmitter<string>();
  
  incrementar(): void {
    this.contador++;
    this.contadorCambio.emit(this.contador);
    
    if (this.contador >= 10) {
      this.valorMaximo.emit('¡Has llegado al máximo!');
    }
  }
  
  decrementar(): void {
    if (this.contador > 0) {
      this.contador--;
      this.contadorCambio.emit(this.contador);
    }
  }
  
  reset(): void {
    this.contador = 0;
    this.contadorCambio.emit(this.contador);
  }
}
```

**contador.component.html**
```html
<div class="contador">
  <h3>Contador: {{ contador }}</h3>
  <button (click)="decrementar()">-</button>
  <button (click)="incrementar()">+</button>
  <button (click)="reset()">Reset</button>
</div>
```

### 2) Configuración del componente padre:

**padre.component.ts**
```typescript
export class PadreComponent {
  valorContador = 0;
  mensaje = '';
  
  // Métodos para recibir eventos del hijo
  onContadorCambio(nuevoValor: number): void {
    this.valorContador = nuevoValor;
    console.log('Contador cambió a:', nuevoValor);
  }
  
  onValorMaximo(mensaje: string): void {
    this.mensaje = mensaje;
    setTimeout(() => this.mensaje = '', 3000); // Limpiar después de 3s
  }
}
```

**padre.component.html**
```html
<div class="app">
  <h2>Mi Aplicación</h2>
  <p>Valor actual del contador: {{ valorContador }}</p>
  <p *ngIf="mensaje" class="alert">{{ mensaje }}</p>
  
  <app-contador 
    (contadorCambio)="onContadorCambio($event)"
    (valorMaximo)="onValorMaximo($event)">
  </app-contador>
</div>
```

---

## Resumen de Binding

### Property Binding - Decorador @Input
```html
<!-- Envío de datos: Padre → Hijo -->
<app-hijo [propiedad]="valor"></app-hijo>
```

### Event Binding - Decorador @Output & EventEmitter
```html
<!-- Recepción de eventos: Hijo → Padre -->
<app-hijo (evento)="metodo($event)"></app-hijo>
```

### Ejemplo completo combinado:
```html
<app-producto-card 
  [producto]="productoSeleccionado"
  [mostrarBotones]="true"
  (productoSeleccionado)="onProductoSeleccionado($event)"
  (agregarAlCarrito)="onAgregarCarrito($event)">
</app-producto-card>
```

---

## Pruebas con Angular

Las **pruebas son esenciales** para garantizar que nuestra aplicación funcione correctamente.

Angular ofrece herramientas para realizar:
- **Pruebas unitarias**: Testear componentes individualmente
- **Pruebas de integración**: Testear la interacción entre componentes

### Comandos para testing:
```bash
# Ejecutar todas las pruebas
ng test

# Ejecutar pruebas en modo watch
ng test --watch

# Ejecutar pruebas con coverage
ng test --code-coverage
```
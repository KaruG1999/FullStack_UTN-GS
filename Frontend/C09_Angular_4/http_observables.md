# 📡 Observables y HTTP en Angular

## 🎯 Introducción a la Programación Reactiva

La **programación reactiva** es un paradigma que permite trabajar con flujos de datos asíncronos de manera eficiente. En Angular, utilizamos **RxJS (Reactive Extensions for JavaScript)** para manejar estos flujos mediante **Observables**.

---

## 🔑 Conceptos Clave

### 1. Observable
Un **Observable** es un flujo de datos que puede emitir múltiples valores a lo largo del tiempo. Es la base de la programación reactiva en Angular.

**Características principales:**
- **Lazy (perezoso):** No se ejecuta hasta que alguien se suscribe a él
- **Asíncrono:** Maneja operaciones que tardan tiempo (llamadas HTTP, timers, eventos)
- **Múltiples valores:** Puede emitir 0, 1 o más valores a lo largo del tiempo

### 2. Suscripción (Subscribe)
Para **recibir los datos** de un Observable, debemos **suscribirnos** a él. Sin suscripción, el Observable no ejecuta ninguna acción.

```typescript
observable$.subscribe(
  (data) => console.log('Datos recibidos:', data),
  (error) => console.error('Error:', error),
  () => console.log('Completado')
);
```

### 3. HttpClient
Es el servicio de Angular que permite realizar llamadas HTTP (GET, POST, PUT, DELETE) y devuelve **Observables** automáticamente.

---

## 🛠️ ¿Qué necesitamos para hacer una llamada HTTP?

1. **Servicio:** Centraliza la lógica para interactuar con el servidor
2. **Observables:** Mecanismo de RxJS para manejar datos asíncronos
3. **Suscripción:** Para recibir y procesar los datos del Observable

---

## 📝 Pasos para implementar llamadas HTTP

### Paso 1: Crear el servicio

Generamos un servicio usando Angular CLI:

```bash
ng generate service services/data
# o abreviado:
ng g s services/data
```

### Paso 2: Configurar el servicio para usar HttpClient

Importamos `HttpClient` y lo inyectamos en el constructor del servicio:

```typescript
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private apiUrl = 'https://api.ejemplo.com/datos';

  constructor(private http: HttpClient) { }
}
```

**Importante:** Asegurarse de tener `HttpClientModule` importado en `app.module.ts` o configurado en `app.config.ts` (Angular 17+):

```typescript
// app.module.ts (Angular < 17)
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  imports: [HttpClientModule]
})
export class AppModule { }

// app.config.ts (Angular 17+)
import { provideHttpClient } from '@angular/common/http';

export const appConfig: ApplicationConfig = {
  providers: [
    provideHttpClient()
  ]
};
```

### Paso 3: Implementar la llamada GET

Creamos un método en el servicio que retorne un Observable:

```typescript
export class DataService {
  private apiUrl = 'https://jsonplaceholder.typicode.com/users';

  constructor(private http: HttpClient) { }

  // Método GET que retorna un Observable
  obtenerUsuarios(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  // Método GET con parámetro
  obtenerUsuarioPorId(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }
}
```

### Paso 4: Usar el servicio en un componente

Inyectamos el servicio y nos suscribimos al Observable:

```typescript
import { Component, OnInit } from '@angular/core';
import { DataService } from './services/data.service';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html'
})
export class UsuariosComponent implements OnInit {
  usuarios: any[] = [];
  cargando: boolean = false;
  error: string = '';

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.obtenerDatos();
  }

  obtenerDatos(): void {
    this.cargando = true;
    
    // Nos suscribimos al Observable
    this.dataService.obtenerUsuarios().subscribe({
      next: (data) => {
        this.usuarios = data;
        this.cargando = false;
      },
      error: (err) => {
        this.error = 'Error al cargar datos';
        this.cargando = false;
        console.error(err);
      },
      complete: () => {
        console.log('Petición completada');
      }
    });
  }
}
```

**Template HTML:**

```html
<div *ngIf="cargando">Cargando...</div>

<div *ngIf="error">{{ error }}</div>

<ul *ngIf="!cargando && !error">
  <li *ngFor="let usuario of usuarios">
    {{ usuario.name }} - {{ usuario.email }}
  </li>
</ul>
```

---

## 🔧 Creación de Observables

### Usando `new Observable()`

```typescript
import { Observable } from 'rxjs';

const miObservable = new Observable((observer) => {
  observer.next('Valor 1');
  observer.next('Valor 2');
  observer.complete();
});

miObservable.subscribe((valor) => console.log(valor));
```

### Usando operadores de RxJS

#### `of` - Emite valores secuencialmente
```typescript
import { of } from 'rxjs';

const numeros$ = of(1, 2, 3, 4, 5);
numeros$.subscribe((num) => console.log(num));
// Output: 1, 2, 3, 4, 5
```

#### `from` - Convierte un array o promesa en Observable
```typescript
import { from } from 'rxjs';

const array$ = from([10, 20, 30]);
array$.subscribe((valor) => console.log(valor));
// Output: 10, 20, 30
```

#### `interval` - Emite valores cada X milisegundos
```typescript
import { interval } from 'rxjs';

const contador$ = interval(1000); // Emite cada 1 segundo
contador$.subscribe((num) => console.log(num));
// Output: 0, 1, 2, 3, 4... (infinitamente)
```

---

## ⚠️ Buenas Prácticas

### 1. Desuscribirse para evitar memory leaks

```typescript
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

export class MiComponente implements OnInit, OnDestroy {
  private suscripcion: Subscription;

  ngOnInit(): void {
    this.suscripcion = this.dataService.obtenerDatos().subscribe(
      (data) => console.log(data)
    );
  }

  ngOnDestroy(): void {
    // Cancelamos la suscripción al destruir el componente
    if (this.suscripcion) {
      this.suscripcion.unsubscribe();
    }
  }
}
```

### 2. Usar `async` pipe en el template (recomendado)

El `async` pipe se suscribe y desuscribe automáticamente:

```typescript
export class MiComponente {
  usuarios$ = this.dataService.obtenerUsuarios();
  
  constructor(private dataService: DataService) { }
}
```

```html
<ul *ngIf="usuarios$ | async as usuarios">
  <li *ngFor="let usuario of usuarios">
    {{ usuario.name }}
  </li>
</ul>
```

---

## 📚 Resumen

| Concepto | Descripción |
|----------|-------------|
| **Observable** | Flujo de datos asíncrono que puede emitir múltiples valores |
| **Subscribe** | Método para recibir los datos del Observable |
| **HttpClient** | Servicio de Angular para hacer peticiones HTTP |
| **Lazy** | Los Observables no se ejecutan hasta que hay una suscripción |
| **RxJS** | Librería para programación reactiva en JavaScript |

---

## 🎓 Ejemplo Completo Integrado

**data.service.ts:**
```typescript
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface Usuario {
  id: number;
  name: string;
  email: string;
}

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private apiUrl = 'https://jsonplaceholder.typicode.com/users';

  constructor(private http: HttpClient) { }

  obtenerUsuarios(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(this.apiUrl);
  }
}
```

**usuarios.component.ts:**
```typescript
import { Component, OnInit } from '@angular/core';
import { DataService } from './services/data.service';

@Component({
  selector: 'app-usuarios',
  template: `
    <h2>Lista de Usuarios</h2>
    <div *ngIf="usuarios$ | async as usuarios; else cargando">
      <ul>
        <li *ngFor="let usuario of usuarios">
          {{ usuario.name }} - {{ usuario.email }}
        </li>
      </ul>
    </div>
    <ng-template #cargando>
      <p>Cargando datos...</p>
    </ng-template>
  `
})
export class UsuariosComponent implements OnInit {
  usuarios$ = this.dataService.obtenerUsuarios();

  constructor(private dataService: DataService) { }

  ngOnInit(): void { }
}
```

---

**💡 Recordatorio:** Los Observables son fundamentales en Angular para manejar operaciones asíncronas de manera elegante y eficiente. ¡Practicar con ellos es esencial para dominar Angular!
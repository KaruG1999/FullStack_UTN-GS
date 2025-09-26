# Angular III - Inyección de Dependencias y Routing

## 📋 Conceptos Fundamentales

### Inyección de Dependencias (Dependency Injection)

La **inyección de dependencias** es un patrón de diseño donde Angular se encarga de crear y proveer las instancias de las clases que nuestros componentes necesitan.

**Beneficios:**

- Desacopla el código
- Facilita el testing
- Mejora la reutilización de código
- Gestión automática del ciclo de vida

### Servicios

Los **servicios** son clases TypeScript que contienen lógica de negocio y datos que pueden ser compartidos entre múltiples componentes.

**Características:**

- Singleton por defecto (una sola instancia)
- Se inyectan en componentes mediante DI
- Separan la lógica de la presentación

### Routing (Enrutamiento)

El **router** de Angular permite la navegación entre diferentes vistas/páginas sin recargar el navegador, creando una Single Page Application (SPA).

---

## 🛠️ Implementación Paso a Paso

### Paso 1: Crear Servicios

#### 1.1 Generar servicios con Angular CLI

```bash
ng generate service services/profile
ng generate service services/resource
ng generate service services/story
```

#### 1.2 Estructura de un Servicio

```typescript
// profile.service.ts
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root", // Disponible en toda la app
})
export class ProfileService {
  private profiles = [
    {
      id: 1,
      name: "Ada Lovelace",
      achievement: "Primera programadora de la historia",
      description: "Creó el primer algoritmo procesado por una máquina",
    },
    {
      id: 2,
      name: "Grace Hopper",
      achievement: "Pionera en programación de computadoras",
      description: 'Desarrolló el primer compilador y acuñó el término "bug"',
    },
  ];

  getProfiles() {
    return this.profiles;
  }

  getProfileById(id: number) {
    return this.profiles.find((profile) => profile.id === id);
  }
}
```

```typescript
// resource.service.ts
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root",
})
export class ResourceService {
  private resources = [
    {
      category: "Comunidades",
      items: [
        { name: "Women Who Code", url: "https://womenwhocode.com" },
        { name: "Girls in Tech", url: "https://girlsintech.org" },
      ],
    },
    {
      category: "Becas",
      items: [
        { name: "Google Women Techmakers", url: "#" },
        { name: "Microsoft Diversity Scholarship", url: "#" },
      ],
    },
  ];

  getResources() {
    return this.resources;
  }
}
```

```typescript
// story.service.ts
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root",
})
export class StoryService {
  private stories = [
    {
      title: 'El primer "bug" informático',
      content:
        "Grace Hopper encontró una polilla real en un relé de la computadora Mark II en 1947",
      author: "Grace Hopper",
    },
    {
      title: "Visión futurista",
      content:
        "Ada Lovelace previó que las máquinas podrían crear música y arte, no solo cálculos",
      author: "Ada Lovelace",
    },
  ];

  getRandomStory() {
    const randomIndex = Math.floor(Math.random() * this.stories.length);
    return this.stories[randomIndex];
  }

  getAllStories() {
    return this.stories;
  }
}
```

### Paso 2: Configurar Routing

#### 2.1 Crear archivo de rutas

```typescript
// app-routing.module.ts
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ProfileComponent } from "./components/profile/profile.component";
import { ResourcesComponent } from "./components/resources/resources.component";
import { HomeComponent } from "./components/home/home.component";

const routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "profiles", component: ProfileComponent },
  { path: "resources", component: ResourcesComponent },
  { path: "**", redirectTo: "" }, // Ruta wildcard para 404
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
```

#### 2.2 Configurar navegación en app.component.html

```html
<!-- app.component.html -->
<nav class="navbar">
  <h1>Mujeres en Tech</h1>
  <ul>
    <li>
      <a
        routerLink="/"
        routerLinkActive="active"
        [routerLinkActiveOptions]="{exact: true}"
        >Inicio</a
      >
    </li>
    <li><a routerLink="/profiles" routerLinkActive="active">Perfiles</a></li>
    <li><a routerLink="/resources" routerLinkActive="active">Recursos</a></li>
  </ul>
</nav>

<!-- Aquí se renderizan las páginas -->
<router-outlet></router-outlet>
```

### Paso 3: Crear Componentes

#### 3.1 Generar componentes

```bash
ng generate component components/profile
ng generate component components/resources
ng generate component components/home
```

#### 3.2 Implementar ProfileComponent

```typescript
// profile.component.ts
import { Component, OnInit } from "@angular/core";
import { ProfileService } from "../../services/profile.service";
import { StoryService } from "../../services/story.service";

@Component({
  selector: "app-profile",
  templateUrl: "./profile.component.html",
  styleUrls: ["./profile.component.css"],
})
export class ProfileComponent implements OnInit {
  profiles: any[] = [];
  featuredStory: any;

  constructor(
    private profileService: ProfileService,
    private storyService: StoryService
  ) {}

  ngOnInit(): void {
    this.profiles = this.profileService.getProfiles();
    this.featuredStory = this.storyService.getRandomStory();
  }
}
```

```html
<!-- profile.component.html -->
<div class="profile-container">
  <h2>Mujeres Destacadas en Tecnología</h2>

  <!-- Anécdota destacada -->
  <div class="featured-story" *ngIf="featuredStory">
    <h3>💡 Momento Clave</h3>
    <h4>{{ featuredStory.title }}</h4>
    <p>{{ featuredStory.content }}</p>
    <small>- {{ featuredStory.author }}</small>
  </div>

  <!-- Lista de perfiles -->
  <div class="profiles-grid">
    <div class="profile-card" *ngFor="let profile of profiles">
      <h3>{{ profile.name }}</h3>
      <p class="achievement">{{ profile.achievement }}</p>
      <p class="description">{{ profile.description }}</p>
    </div>
  </div>
</div>
```

#### 3.3 Implementar ResourcesComponent

```typescript
// resources.component.ts
import { Component, OnInit } from "@angular/core";
import { ResourceService } from "../../services/resource.service";
import { StoryService } from "../../services/story.service";

@Component({
  selector: "app-resources",
  templateUrl: "./resources.component.html",
  styleUrls: ["./resources.component.css"],
})
export class ResourcesComponent implements OnInit {
  resources: any[] = [];
  inspirationalStory: any;

  constructor(
    private resourceService: ResourceService,
    private storyService: StoryService
  ) {}

  ngOnInit(): void {
    this.resources = this.resourceService.getResources();
    this.inspirationalStory = this.storyService.getRandomStory();
  }
}
```

```html
<!-- resources.component.html -->
<div class="resources-container">
  <h2>Recursos para Mujeres en Tech</h2>

  <!-- Anécdota inspiracional -->
  <div class="inspiration-story" *ngIf="inspirationalStory">
    <h3>✨ Inspiración</h3>
    <blockquote>
      "{{ inspirationalStory.content }}"
      <cite>- {{ inspirationalStory.author }}</cite>
    </blockquote>
  </div>

  <!-- Recursos por categoría -->
  <div class="resources-section">
    <div class="category" *ngFor="let category of resources">
      <h3>{{ category.category }}</h3>
      <ul class="resource-list">
        <li *ngFor="let item of category.items">
          <a [href]="item.url" target="_blank">{{ item.name }}</a>
        </li>
      </ul>
    </div>
  </div>
</div>
```

## 🔗 Flujo de Datos

```
┌─────────────────┐    ┌──────────────────┐    ┌─────────────────┐
│   Services      │    │   Components     │    │   Templates     │
│                 │    │                  │    │                 │
│ ProfileService  │────▶│ ProfileComponent │────▶│ profile.html    │
│ ResourceService │    │ ResourcesComponent│    │ resources.html  │
│ StoryService    │    │                  │    │                 │
│                 │    │                  │    │                 │
└─────────────────┘    └──────────────────┘    └─────────────────┘
        ▲                        ▲
        │                        │
        │              ┌─────────────────┐
        │              │   Router        │
        └──────────────│   Navigation    │
                       │   <router-outlet>│
                       └─────────────────┘
```

## 🎯 Comandos Principales

### Generar elementos

```bash
# Crear servicio
ng generate service services/nombre-servicio

# Crear componente
ng generate component components/nombre-componente

# Crear módulo de routing
ng generate module app-routing --flat --module=app
```

## 🔑 Conceptos Clave para Recordar

- **@Injectable()**: Decorador que marca una clase como servicio inyectable
- **providedIn: 'root'**: Hace el servicio disponible en toda la aplicación
- **constructor()**: Donde se inyectan las dependencias
- **RouterModule**: Módulo que habilita el routing en Angular
- **<router-outlet>**: Directiva donde se renderizan los componentes de las rutas
- **routerLink**: Directiva para navegación declarativa
- **routerLinkActive**: Directiva para aplicar estilos a rutas activas

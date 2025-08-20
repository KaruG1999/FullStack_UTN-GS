# Introducción a CSS - Conceptos Fundamentales

## ¿Qué es CSS?

**CSS** significa **Cascading Style Sheets** o **Hojas de Estilo en Cascada**. Es el lenguaje que se utiliza para dar estilo y presentación a las páginas web. CSS controla cómo se ven los elementos HTML, incluyendo:

- 🎨 **Colores** de texto y fondo
- 📝 **Fuentes** y tipografías
- 📏 **Márgenes** y espaciado
- 📍 **Posicionamiento** de elementos
- 🖼️ **Diseño** y layout general

## Sintaxis de CSS

La sintaxis básica de CSS sigue esta estructura:

```css
selector {
  propiedad: valor;
  propiedad: valor;
}
```

### Ejemplo práctico:

```css
h1 {
  color: blue;
  font-size: 24px;
  margin-top: 20px;
}
```

## Selectores en CSS

Los selectores determinan qué elementos HTML serán afectados por los estilos:

### Tipos de Selectores:

| Selector         | Sintaxis     | Descripción                                          | Ejemplo         |
| ---------------- | ------------ | ---------------------------------------------------- | --------------- |
| **Elemento**     | `elemento`   | Selecciona todos los elementos del tipo especificado | `p { }`         |
| **Clase**        | `.clase`     | Selecciona elementos con una clase específica        | `.mi-clase { }` |
| **ID**           | `#id`        | Selecciona un elemento con ID único                  | `#mi-id { }`    |
| **Universal**    | `*`          | Selecciona todos los elementos                       | `* { }`         |
| **Descendiente** | `padre hijo` | Selecciona hijos dentro de un padre                  | `div p { }`     |

### Ejemplos de Selectores:

```css
/* Selector de elemento */
h1 {
  color: #2c3e50;
}

/* Selector de clase */
.destacado {
  background-color: yellow;
}

/* Selector de ID */
#encabezado {
  font-size: 32px;
}

/* Selector descendiente */
nav ul li {
  display: inline-block;
}
```

## ¿Dónde Aplicar CSS?

Existen tres formas principales de aplicar CSS:

### 1. **CSS Interno** (En el HTML)

```html
<head>
  <style>
    body {
      background-color: #f0f0f0;
    }
  </style>
</head>
```

### 2. **CSS Externo** (Archivo separado)

```html
<head>
  <link rel="stylesheet" href="style.css" />
</head>
```

### 3. **CSS Inline** (En línea)

```html
<p style="color: red; font-size: 18px;">Texto con estilo</p>
```

> 💡 **Recomendación**: Usar CSS externo para mantener el código organizado y reutilizable.

## Propiedades de CSS Más Comunes

### Propiedades de Texto y Fuentes:

- `color` - Color del texto
- `font-family` - Tipo de fuente
- `font-size` - Tamaño de la fuente
- `font-weight` - Grosor de la fuente
- `text-align` - Alineación del texto

### Propiedades de Fondo:

- `background-color` - Color de fondo
- `background-image` - Imagen de fondo

### Propiedades de Espaciado:

- `margin` - Margen exterior
- `padding` - Relleno interior
- `width` - Ancho
- `height` - Alto

### Propiedades de Borde:

- `border` - Borde completo
- `border-radius` - Bordes redondeados

## El Modelo de Caja (Box Model)

En CSS, cada elemento se representa como una **caja rectangular** que tiene cuatro áreas:

```
┌─────────────────────────────────┐
│           MARGEN                │
│  ┌─────────────────────────┐    │
│  │        BORDE            │    │
│  │  ┌─────────────────┐    │    │
│  │  │    RELLENO      │    │    │
│  │  │  ┌───────────┐  │    │    │
│  │  │  │ CONTENIDO │  │    │    │
│  │  │  └───────────┘  │    │    │
│  │  └─────────────────┘    │    │
│  └─────────────────────────┘    │
└─────────────────────────────────┘
```

### Componentes del Box Model:

1. **📄 Contenido**: Lo que está dentro del elemento (texto, imágenes, etc.)
2. **🛡️ Relleno (padding)**: Espacio transparente alrededor del contenido
3. **🔲 Borde (border)**: Línea que rodea el contenido y el relleno
4. **🌌 Margen (margin)**: Espacio transparente fuera del borde

### Ejemplo del Box Model:

```css
.caja {
  width: 200px; /* Ancho del contenido */
  height: 100px; /* Alto del contenido */
  padding: 20px; /* Relleno de 20px en todos los lados */
  border: 2px solid blue; /* Borde sólido azul de 2px */
  margin: 10px; /* Margen de 10px en todos los lados */
}
```

**Tamaño total de la caja**:

- Ancho total: 200px (contenido) + 40px (padding) + 4px (border) + 20px (margin) = **264px**
- Alto total: 100px (contenido) + 40px (padding) + 4px (border) + 20px (margin) = **164px**

## Media Queries: Diseño Responsivo

Las **Media Queries** permiten aplicar estilos CSS específicos según las características del dispositivo (tamaño de pantalla, resolución, etc.).

### Sintaxis de Media Queries:

```css
@media screen and (condición) {
  /* Estilos que se aplican cuando la condición es verdadera */
}
```

### Breakpoints Comunes:

| Dispositivo | Tamaño         | Media Query                                                    |
| ----------- | -------------- | -------------------------------------------------------------- |
| **Móvil**   | Hasta 767px    | `@media screen and (max-width: 767px)`                         |
| **Tablet**  | 768px - 1023px | `@media screen and (min-width: 768px) and (max-width: 1023px)` |
| **Desktop** | 1024px+        | `@media screen and (min-width: 1024px)`                        |

### Ejemplos Prácticos:

```css
/* Estilos base para móviles */
body {
  background-color: #f5f5f5;
  font-size: 16px;
}

/* Estilos para tablets (768px en adelante) */
@media screen and (min-width: 768px) {
  body {
    background-color: #e8f4f8;
    font-size: 18px;
  }

  .container {
    max-width: 800px;
    margin: 0 auto;
  }
}

/* Estilos para desktop (1280px en adelante) */
@media screen and (min-width: 1280px) {
  body {
    background-color: #f0f8e8;
    font-size: 20px;
  }

  .container {
    max-width: 1200px;
  }

  h1 {
    font-size: 2.5em;
  }
}
```

## Conceptos Clave para Recordar

### 🎯 **Cascada**

Los estilos "caen en cascada", lo que significa que:

- Los estilos más específicos tienen prioridad
- Los estilos posteriores sobrescriben los anteriores
- Los estilos inline > internos > externos

### 🎨 **Especificidad**

Orden de prioridad de selectores:

1. IDs (`#mi-id`) - Mayor especificidad
2. Clases (`.mi-clase`) - Especificidad media
3. Elementos (`p`, `div`) - Menor especificidad

### 📱 **Mobile First**

Enfoque recomendado: comenzar diseñando para móviles y luego agregar estilos para pantallas más grandes.

### 🔧 **Herramientas de Desarrollo**

- Usar las herramientas de desarrollador del navegador (F12)
- Inspeccionar elementos para ver estilos aplicados
- Probar diferentes tamaños de pantalla

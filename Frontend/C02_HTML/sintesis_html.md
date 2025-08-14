# Síntesis de Clase: Fundamentos de HTML

## ¿Qué es HTML?

HTML (HyperText Markup Language) es el lenguaje de marcado estándar para crear páginas web. Define la estructura y el contenido de una página web mediante elementos y etiquetas, permitiendo organizar texto, imágenes, enlaces y otros elementos multimedia de forma semántica y accesible.

## Estructura Básica de HTML

```html
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Título de la página</title>
</head>
<body>
    <!-- Contenido de la página -->
</body>
</html>
```

## Layout (Diseño) en HTML

El layout se refiere a la disposición y organización visual de los elementos en una página web. HTML proporciona elementos estructurales para crear layouts semánticos:

- **`<header>`**: Encabezado de la página o sección
- **`<nav>`**: Navegación principal
- **`<main>`**: Contenido principal
- **`<section>`**: Secciones temáticas
- **`<article>`**: Contenido independiente
- **`<aside>`**: Contenido complementario
- **`<footer>`**: Pie de página

## Elementos Semánticos y sus Definiciones

Los elementos semánticos proporcionan significado al contenido, mejorando la accesibilidad y SEO:

- **`<header>`**: Introduce contenido o elementos de navegación
- **`<nav>`**: Enlaces de navegación principales
- **`<main>`**: Contenido principal único de la página
- **`<section>`**: Sección temática con encabezado propio
- **`<article>`**: Contenido autónomo y reutilizable
- **`<aside>`**: Contenido tangencial (sidebar, notas)
- **`<footer>`**: Información de cierre o contacto
- **`<figure>`**: Contenido referenciado (imágenes, diagramas)
- **`<figcaption>`**: Descripción de figure
- **`<time>`**: Fechas y horarios
- **`<mark>`**: Texto resaltado

## Tags Básicas

### Encabezados
```html
<h1>Título principal</h1>
<h2>Subtítulo</h2>
<h3>Encabezado de tercer nivel</h3>
<!-- h4, h5, h6 -->
```

### Texto
```html
<p>Párrafo</p>
<strong>Texto importante</strong>
<em>Texto enfatizado</em>
<br>Salto de línea
<hr>Línea horizontal
```

### Contenedores
```html
<div>Contenedor genérico</div>
<span>Contenedor en línea</span>
```

## Atributos

Los atributos proporcionan información adicional sobre los elementos:

### Atributos Globales
- **`id`**: Identificador único
- **`class`**: Clase CSS para estilos
- **`lang`**: Idioma del contenido
- **`title`**: Información adicional (tooltip)
- **`style`**: Estilos CSS inline

### Ejemplos
```html
<div id="contenedor" class="principal" lang="es" title="Contenedor principal">
<p style="color: blue;">Texto azul</p>
```

## Listas Ordenadas y Desordenadas

### Lista Desordenada (ul)
```html
<ul>
    <li>Elemento 1</li>
    <li>Elemento 2</li>
    <li>Elemento 3</li>
</ul>
```

### Lista Ordenada (ol)
```html
<ol>
    <li>Primer paso</li>
    <li>Segundo paso</li>
    <li>Tercer paso</li>
</ol>
```

### Lista de Definiciones
```html
<dl>
    <dt>Término</dt>
    <dd>Definición del término</dd>
</dl>
```

## Accesibilidad y ARIA

ARIA (Accessible Rich Internet Applications) mejora la accesibilidad para usuarios con discapacidades:

### Atributos ARIA Principales
- **`aria-label`**: Etiqueta accesible
- **`aria-describedby`**: Referencia a descripción
- **`aria-hidden`**: Oculta elementos de lectores de pantalla
- **`role`**: Define el propósito del elemento

### Ejemplos
```html
<button aria-label="Cerrar ventana">×</button>
<img src="logo.png" alt="Logo de la empresa" aria-describedby="logo-desc">
<p id="logo-desc">Logotipo oficial de nuestra compañía</p>
```

## Imágenes

```html
<!-- Imagen básica -->
<img src="imagen.jpg" alt="Descripción de la imagen">

<!-- Imagen con atributos adicionales -->
<img src="foto.jpg" 
     alt="Descripción accesible" 
     width="300" 
     height="200"
     loading="lazy">

<!-- Imagen con figure -->
<figure>
    <img src="grafico.png" alt="Gráfico de ventas 2024">
    <figcaption>Evolución de ventas durante el año 2024</figcaption>
</figure>
```

## Enlaces

### Enlaces Básicos
```html
<!-- Enlace externo -->
<a href="https://www.ejemplo.com">Sitio web externo</a>

<!-- Enlace interno -->
<a href="pagina2.html">Otra página</a>

<!-- Enlace a sección -->
<a href="#seccion1">Ir a sección 1</a>

<!-- Enlace de email -->
<a href="mailto:contacto@ejemplo.com">Enviar email</a>

<!-- Enlace de teléfono -->
<a href="tel:+1234567890">Llamar</a>
```

### Atributos de Enlaces
```html
<a href="documento.pdf" target="_blank" rel="noopener">
    Abrir PDF en nueva pestaña
</a>
```

## Navegación

### Navegación Principal
```html
<nav aria-label="Navegación principal">
    <ul>
        <li><a href="inicio.html">Inicio</a></li>
        <li><a href="servicios.html">Servicios</a></li>
        <li><a href="contacto.html">Contacto</a></li>
    </ul>
</nav>
```

### Breadcrumb (Migas de pan)
```html
<nav aria-label="Breadcrumb">
    <ol>
        <li><a href="/">Inicio</a></li>
        <li><a href="/categoria">Categoría</a></li>
        <li aria-current="page">Página actual</li>
    </ol>
</nav>
```

## Formularios

### Estructura Básica
```html
<form action="/procesar" method="POST">
    <!-- Campos de texto -->
    <label for="nombre">Nombre:</label>
    <input type="text" id="nombre" name="nombre" required>
    
    <!-- Email -->
    <label for="email">Email:</label>
    <input type="email" id="email" name="email" required>
    
    <!-- Contraseña -->
    <label for="password">Contraseña:</label>
    <input type="password" id="password" name="password" required>
    
    <!-- Textarea -->
    <label for="mensaje">Mensaje:</label>
    <textarea id="mensaje" name="mensaje" rows="4"></textarea>
    
    <!-- Select -->
    <label for="pais">País:</label>
    <select id="pais" name="pais">
        <option value="ar">Argentina</option>
        <option value="br">Brasil</option>
        <option value="cl">Chile</option>
    </select>
    
    <!-- Radio buttons -->
    <fieldset>
        <legend>Género:</legend>
        <input type="radio" id="masculino" name="genero" value="M">
        <label for="masculino">Masculino</label>
        
        <input type="radio" id="femenino" name="genero" value="F">
        <label for="femenino">Femenino</label>
    </fieldset>
    
    <!-- Checkbox -->
    <input type="checkbox" id="terminos" name="terminos" required>
    <label for="terminos">Acepto los términos y condiciones</label>
    
    <!-- Botones -->
    <button type="submit">Enviar</button>
    <button type="reset">Limpiar</button>
</form>
```

### Validación y Accesibilidad en Formularios
```html
<div>
    <label for="telefono">Teléfono:</label>
    <input type="tel" 
           id="telefono" 
           name="telefono" 
           pattern="[0-9]{10}" 
           aria-describedby="tel-help"
           required>
    <div id="tel-help">Ingrese 10 dígitos sin espacios</div>
</div>
```

## Puntos Clave para Recordar

1. **Semántica**: Usa siempre la etiqueta más apropiada para el contenido
2. **Accesibilidad**: Incluye atributos alt, labels y ARIA cuando sea necesario
3. **Estructura**: Mantén una jerarquía lógica con encabezados h1-h6
4. **Validación**: Asegúrate de que tu HTML sea válido
5. **Formularios**: Siempre asocia labels con inputs usando el atributo for/id
6. **Navegación**: Proporciona múltiples formas de navegar por el sitio
7. **Imágenes**: Incluye texto alternativo descriptivo para todas las imágenes
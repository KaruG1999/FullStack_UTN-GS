# CSS Flexbox - Apunte de Clase

## ¿Qué es Flexbox?

Flexbox (Flexible Box Layout) es un sistema de layout en CSS que permite organizar elementos de manera flexible y eficiente. Facilita la distribución del espacio y la alineación de elementos dentro de un contenedor, incluso cuando su tamaño es desconocido o dinámico.

## display: flex

Para activar Flexbox en un contenedor, utilizamos:

```css
.contenedor {
    display: flex;
}
```

Al aplicar `display: flex` a un elemento, este se convierte en un **flex container** y sus hijos directos se convierten en **flex items**.

## flex-direction

Define la dirección principal del contenedor flex.

```css
.contenedor {
    display: flex;
    flex-direction: row; /* valor por defecto */
}
```

**Valores posibles:**
- `row` (por defecto): Los elementos se alinean horizontalmente de izquierda a derecha
- `row-reverse`: Los elementos se alinean horizontalmente de derecha a izquierda
- `column`: Los elementos se alinean verticalmente de arriba hacia abajo
- `column-reverse`: Los elementos se alinean verticalmente de abajo hacia arriba

## justify-content

Controla la alineación de los elementos a lo largo del **eje principal**.

```css
.contenedor {
    display: flex;
    justify-content: flex-start; /* valor por defecto */
}
```

**Comportamiento según flex-direction:**
- Si `flex-direction: row` → justify-content controla la alineación **HORIZONTAL**
- Si `flex-direction: column` → justify-content controla la alineación **VERTICAL**

**Valores comunes:**
- `flex-start`: Elementos al inicio del contenedor
- `flex-end`: Elementos al final del contenedor
- `center`: Elementos centrados
- `space-between`: Espacio igual entre elementos
- `space-around`: Espacio igual alrededor de cada elemento
- `space-evenly`: Espacio perfectamente distribuido

## align-items

Controla la alineación de los elementos a lo largo del **eje transversal**.

```css
.contenedor {
    display: flex;
    align-items: stretch; /* valor por defecto */
}
```

**Comportamiento según flex-direction:**
- Si `flex-direction: row` → align-items controla la alineación **VERTICAL**
- Si `flex-direction: column` → align-items controla la alineación **HORIZONTAL**

**Valores comunes:**
- `stretch`: Los elementos se estiran para llenar el contenedor
- `flex-start`: Elementos al inicio del eje transversal
- `flex-end`: Elementos al final del eje transversal
- `center`: Elementos centrados en el eje transversal
- `baseline`: Elementos alineados por su línea base

## Resumen de Ejes

### Cuando flex-direction: row (por defecto)
- **Eje principal:** Horizontal
- **Eje transversal:** Vertical
- `justify-content` → Controla alineación horizontal
- `align-items` → Controla alineación vertical

### Cuando flex-direction: column
- **Eje principal:** Vertical
- **Eje transversal:** Horizontal
- `justify-content` → Controla alineación vertical
- `align-items` → Controla alineación horizontal

## Ejemplo Práctico

```css
.contenedor {
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
    height: 100vh;
}

.item {
    background-color: #f0f0f0;
    padding: 20px;
    margin: 10px;
}
```

```html
<div class="contenedor">
    <div class="item">Item 1</div>
    <div class="item">Item 2</div>
    <div class="item">Item 3</div>
</div>
```

Este ejemplo centrará los elementos tanto horizontal como verticalmente en la pantalla.

---

*Nota: Al cambiar `flex-direction`, los ejes se invierten y el comportamiento de `justify-content` y `align-items` cambia accordingly.*
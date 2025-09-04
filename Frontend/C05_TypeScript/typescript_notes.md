# Introducción a TypeScript

## ¿Qué es TypeScript?

TypeScript es un **superset de JavaScript** desarrollado por Microsoft que añade **tipado estático** al lenguaje. Esto significa que:

- Permite detectar errores de tipo antes de ejecutar el código
- Hace el desarrollo más seguro y predecible
- Se compila a JavaScript, por lo que puede ejecutarse en cualquier entorno que soporte JavaScript

## Instalación y Configuración

### Instalación Global
```bash
npm install -g typescript
```

### Verificar la Instalación
```bash
tsc --version
```

### Compilar un Archivo TypeScript
```bash
tsc archivo.ts
```
Este comando genera un archivo `archivo.js` que puede ejecutarse en cualquier entorno JavaScript.

## Tipado Estático y Declaración de Variables

TypeScript permite declarar tipos de datos explícitamente:

### Tipos Básicos
```typescript
let nombre: string = "Juan";
let edad: number = 25;
let esEstudiante: boolean = true;
```

### Declaración de Variables
- **`let`**: Para variables que pueden cambiar durante la ejecución
- **`const`**: Para valores que no cambian (constantes)

```typescript
let contador: number = 0;
const PI: number = 3.14159;
```

## Tipado en Funciones

Podemos especificar el tipo de los parámetros y el tipo de retorno:

```typescript
function saludar(nombre: string): string {
    return `Hola, ${nombre}!`;
}

function sumar(a: number, b: number): number {
    return a + b;
}

// Función sin retorno (void)
function mostrarMensaje(mensaje: string): void {
    console.log(mensaje);
}
```

## Arrays y Tipos en Arrays

TypeScript permite definir el tipo de elementos que un array puede contener:

```typescript
// Array de números
let numeros: number[] = [1, 2, 3, 4, 5];

// Array de strings
let frutas: string[] = ["manzana", "banana", "naranja"];

// Sintaxis alternativa con Array<tipo>
let colores: Array<string> = ["rojo", "verde", "azul"];
```

## Interfaces y Objetos

Las interfaces permiten definir la estructura de un objeto:

```typescript
interface Persona {
    nombre: string;
    edad: number;
    email?: string; // Propiedad opcional
}

let usuario: Persona = {
    nombre: "Ana",
    edad: 30,
    email: "ana@email.com"
};

// Sin email (es opcional)
let otroUsuario: Persona = {
    nombre: "Carlos",
    edad: 25
};
```

## Unión de Tipos

Con las uniones (`|`), una variable puede aceptar más de un tipo de dato:

```typescript
let id: string | number;
id = "ABC123";  // Válido
id = 12345;     // También válido

function formatearId(id: string | number): string {
    return `ID: ${id}`;
}
```

## Métodos de Arrays

### Método forEach()
Ejecuta una función para cada elemento del array:

```typescript
let numeros: number[] = [1, 2, 3, 4, 5];

numeros.forEach((numero: number) => {
    console.log(`Número: ${numero}`);
});

// Con índice
numeros.forEach((numero: number, indice: number) => {
    console.log(`Posición ${indice}: ${numero}`);
});
```

### Método filter()
Crea un nuevo array con los elementos que cumplen cierta condición:

```typescript
let numeros: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

// Filtrar números pares
let pares: number[] = numeros.filter((numero: number) => numero % 2 === 0);
console.log(pares); // [2, 4, 6, 8, 10]

// Filtrar strings por longitud
let palabras: string[] = ["casa", "automóvil", "sol", "programación"];
let palabrasLargas: string[] = palabras.filter((palabra: string) => palabra.length > 5);
console.log(palabrasLargas); // ["automóvil", "programación"]
```

## Referentes en la Comunidad TypeScript

### Danielle Adams
Ingeniera en la infraestructura de TypeScript en Microsoft. Ha contribuido directamente al desarrollo del compilador de TypeScript y es una voz importante en la comunidad sobre cómo mejorar el lenguaje.

### Sara Vieira
Ingeniera de front-end y defensora activa del uso de TypeScript en la comunidad de JavaScript. Conocida por sus charlas y contribuciones en conferencias de tecnología, promoviendo TypeScript para el desarrollo web moderno.

### Emma Wedekind
Defensora del desarrollo front-end, incluidos JavaScript y TypeScript. Cofundadora de la comunidad "Ladybug Podcast", enfocada en apoyar a mujeres desarrolladoras. Comparte recursos sobre TypeScript y es una gran influencia en la comunidad de tecnología.

## Recursos Adicionales

- **Playground online**: [TypeScript Playground](https://www.typescriptlang.org/play) - Para practicar y experimentar con TypeScript en el navegador
- **Documentación oficial**: [TypeScript Docs](https://www.typescriptlang.org/docs/)

---

*Nota: Este apunte cubre los conceptos fundamentales de TypeScript. La práctica constante y la exploración de ejemplos más complejos ayudarán a consolidar estos conocimientos.*
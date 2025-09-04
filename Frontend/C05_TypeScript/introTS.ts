// Ejercicio 1
// Declarar una variable de tipo string llamada "nombre" y asignarle tu nombre.
const nombre: string = "Karen";

// Declarar una variable de tipo number llamada "edad" y asignarle tu edad.
const edad: number = 26;

// Declarar una variable de tipo boolean llamada "esEstudiante" y asignarle true o false.
const esEstudiante: boolean = true;

// Imprimir en consola el valor de cada variable usando console.log()
console.log("Mi nombre es:", nombre);
console.log("Tengo", edad);
console.log("Actualmente soy estudiante: ", esEstudiante);

// Ejercicio 2
// Declarar una función que reciba dos números como parámetros y retorne su suma.
// Asegurar que los parámetros y el valor de retorno sean de tipo number.

function sumar(a: number, b: number): number {
  return a + b;
}

// Llamar a la función e imprimir el resultado.
console.log("Resultado de suma: ", sumar(5, 5));

// Realizar otra función que reste dos números. (podría usar a y b también?)

function resta(c: number, d: number): number {
  return c - d;
}

// Realizar otra función que multiplique dos números.
function multiplicacion(e: number, f: number): number {
  return e * f;
}

// Ejercicio 3
// Crear un array de números llamado "numeros" y agregar algunos valores.
// Usa un bucle para imprimir cada número multiplicado por 2 (usando forEach())

const numeros: number[] = [1, 2, 3, 4];
numeros.forEach((num) => {
  console.log(num);
});

// Ejercicio 4
// Declarar una interfaz "Persona" con las propiedades: nombre (string), edad (number), y esEstudiante (boolean).
// Crear tres objetos que sigan la estructura de la interfaz.
// Imprimir en consola.

interface Persona {
  nombre: string;
  edad: number;
  esEstudiante: boolean;
}

const persona1: Persona = { nombre: "Karen", edad: 26, esEstudiante: true };
const persona2: Persona = { nombre: "Lucas", edad: 30, esEstudiante: false };
const persona3: Persona = { nombre: "Maria", edad: 26, esEstudiante: true };

function imprimirPersonas(persona: Persona): string {
  return `Nombre: ${persona.nombre}, Edad: ${persona.edad}, Es estudiante?: ${persona.esEstudiante}`;
}

console.log(imprimirPersonas(persona1));
console.log(imprimirPersonas(persona2));
console.log(imprimirPersonas(persona3));

// Ejercicio 5
// Declara una variable que pueda ser de tipo string o number.
// Asigna un valor string y luego cambia su valor a number.
// Imprimir en consola ambos casos.

let valor: string | number;

valor = "soy un string";
console.log(valor);
valor = 10;
console.log(valor);

// Ejercicio 6
// Definir una interfaz "Producto" con propiedades: nombre (string), precio (number), y enStock (boolean).
// Crear un array de "productos" con seis objetos que sigan la interfaz.
// Crear una función que reciba el array y retorne los productos en stock (sólo en stock).
// Crear otra función que reciba el array y retorne los productos sin stock (sólo sin stock).
// Se puede usar método filter() para esto. https://developer.mozilla.org/es/docs/Web/JavaScript/Reference/Global_Objects/Array/filter

interface Producto {
  nombre: string;
  precio: number;
  enStock: boolean;
}

// Array con seis productos (otra forma de declarar obj directamente)
let arrayProductos: Producto[] = [
  { nombre: "Notebook", precio: 1500, enStock: true },
  { nombre: "Mouse", precio: 20, enStock: false },
  { nombre: "Teclado", precio: 45, enStock: true },
  { nombre: "Monitor", precio: 300, enStock: false },
  { nombre: "Silla Gamer", precio: 250, enStock: true },
  { nombre: "Auriculares", precio: 80, enStock: false },
];

// Función para obtener productos en stock
function obtenerEnStock(productos: Producto[]): Producto[] {
  return productos.filter((producto) => producto.enStock);
}

// Función para obtener productos sin stock
function obtenerSinStock(productos: Producto[]): Producto[] {
  return productos.filter((producto) => !producto.enStock);
}

// Probar en consola
console.log("Productos en stock:");
console.log(obtenerEnStock(arrayProductos));

console.log("Productos sin stock:");
console.log(obtenerSinStock(arrayProductos));

// Ejercicio 7
// Definir una interfaz "Cliente" con 4 propiedades a elección (por ahora solamente tipos string, booleanos y numbers).
// Crear un array de "clientes" con seis objetos que sigan la interfaz.
// Crear una función que reciba el array y retorne los clientes que cumplan una condición (segun el booleano que hayamos creado).
// Crear otra función que reciba el array y retorne los clientes que cumplan la condición inversa al punto de arriba (mismo booleano que hayamos elegido).
// Se puede usar método filter() para esto. https://developer.mozilla.org/es/docs/Web/JavaScript/Reference/Global_Objects/Array/filter

interface Cliente {
  nombre: string;
  edad: number;
  email: string;
  esVip: boolean;
}

// array con seis clientes
let clientes: Cliente[] = [
  { nombre: "Karen", edad: 26, email: "karen@example.com", esVip: true },
  { nombre: "Lucas", edad: 30, email: "lucas@example.com", esVip: false },
  { nombre: "Maria", edad: 22, email: "maria@example.com", esVip: true },
  { nombre: "Sofia", edad: 28, email: "sofia@example.com", esVip: false },
  { nombre: "Martin", edad: 35, email: "martin@example.com", esVip: true },
  { nombre: "Carla", edad: 27, email: "carla@example.com", esVip: false },
];

// Función para obtener clientes VIP
function obtenerClientesVip(clientes: Cliente[]): Cliente[] {
  return clientes.filter((cliente) => cliente.esVip);
}

// Función para obtener clientes NO VIP
function obtenerClientesNoVip(clientes: Cliente[]): Cliente[] {
  return clientes.filter((cliente) => !cliente.esVip);
}

// imprimir resultado
console.log("Clientes VIP:");
console.log(obtenerClientesVip(clientes));

console.log("Clientes NO VIP:");
console.log(obtenerClientesNoVip(clientes));

//Ejercicio 8: Catálogo de Productos - forEach
//Crear un array llamado catalogo con varios objetos de productos. Cada producto debe tener las propiedades nombre (string) y precio (number).
//Usar forEach para imprimir el nombre y el precio de cada producto. https://developer.mozilla.org/es/docs/Web/JavaScript/Reference/Global_Objects/Array/forEach

let catalogo = [
  { nombre: "Notebook", precio: 1500 },
  { nombre: "Mouse", precio: 20 },
  { nombre: "Teclado", precio: 45 },
  { nombre: "Monitor", precio: 300 },
  { nombre: "Auriculares", precio: 35 },
  { nombre: "Silla Gamer", precio: 250 },
];

console.log("Catálogo de productos:");
catalogo.forEach((producto) => {
  console.log(`Nombre: ${producto.nombre}, Precio: ${producto.precio}`);
});

//Ejercicio 9: Catálogo de Productos - filter
//Utilizar filter para crear un nuevo array llamado productosBaratos que solo contenga los productos con precio menor a 50. https://developer.mozilla.org/es/docs/Web/JavaScript/Reference/Global_Objects/Array/filter
//Imprimor productosBaratos en la consola.

let productosBaratos = catalogo.filter((producto) => producto.precio < 50);

console.log("Productos baratos (< $50):");
console.log(productosBaratos);

//Ejercicio 10: Actualización de Inventario - map
//Utilizar map para crear un nuevo array catalogoConDescuento, donde cada producto tenga un 10% menos de precio. https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/map
//Imprimir catalogoConDescuento en la consola.

let catalogoConDescuento = catalogo.map((producto) => {
  return {
    nombre: producto.nombre,
    precio: producto.precio * 0.9, // 10% menos
  };
});

console.log("Catálogo con 10% de descuento:");
console.log(catalogoConDescuento);

//Ejercicio 11: Búsqueda de Usuario - find
//Crear un array llamado usuarios con varios objetos de usuario. Cada usuario debe tener id (number), nombre (string) y activo (boolean).
//Usar find para buscar el usuario con el id 3. https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/find
//Imprimir en la consola el objeto del usuario encontrado.

interface Usuario {
  id: number;
  nombre: string;
  activo: boolean;
}

let usuarios: Usuario[] = [
  { id: 1, nombre: "Karen", activo: true },
  { id: 2, nombre: "Lucas", activo: false },
  { id: 3, nombre: "Maria", activo: true },
  { id: 4, nombre: "Sofia", activo: false },
];

let usuarioEncontrado = usuarios.find((usuario) => usuario.id === 3);

console.log("Usuario con id=3:");
console.log(usuarioEncontrado);

//Ejercicio 12: Contador de Usuarios Activos - filter y length
//Utilizar filter para crear un nuevo array usuariosActivos que contenga solo los usuarios con activo: true.
//Usar la propiedad length para contar cuántos usuarios activos hay y muestra el resultado en la consola. https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/length

let usuariosActivos = usuarios.filter((usuario) => usuario.activo);

console.log("Usuarios activos:");
console.log(usuariosActivos);
console.log(`Cantidad de usuarios activos: ${usuariosActivos.length}`);

//Ejercicio 13: Actualización de Estado de Usuarios
//Usando un bucle forEach, cambiar la propiedad activo de cada usuario a false.
//Imprimir el array usuarios para verificar que todos los usuarios están inactivos.

usuarios.forEach((usuario) => {
  usuario.activo = false;
});

console.log("Todos los usuarios ahora están inactivos:");
console.log(usuarios);

//Ejercicio 14: Formateo de Productos para Mostrar - map
//Usar el array catalogo.
//Utilizar map para crear un nuevo array productosFormato que contenga el nombre y precio de cada producto como un string en el formato "Producto: [nombre], Precio: $[precio]".
//Para esto podemos usar template strings `string text ${expression} string text`: https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Template_literals
//Imprimir el array productosFormato en la consola.

let productosFormato = catalogo.map(
  (producto) => `Producto: ${producto.nombre}, Precio: ${producto.precio}`
);

console.log("Productos en formato string:");
console.log(productosFormato);

//Ejercicio 15:
//Con los datos que tenemos, crear una interfaz "User" y aplicarla, para que el siguiente codigo compile sin errores:

interface User {
  name: string;
  age: number;
  occupation: string;
}

const users: User[] = [
  {
    name: "Max Mustermann",
    age: 25,
    occupation: "Chimney sweep",
  },
  {
    name: "Kate Müller",
    age: 23,
    occupation: "Astronaut",
  },
];

function logUser(user: User): string {
  return ` - ${user.name}, ${user.age}`;
}

console.log("Users:");
users.forEach((user) => console.log(logUser(user)));

//Ejercicio 16:
//Vamos a volver a usar la interfaz User del ejercicio anterior.
//Crear una nueva interfaz Admin segun los datos que tenemos.
//Corregir el type Person para que acepte dos tipos: User y la nueva interfaz.
//Corregir la implementacion para aplicar el type Person para que el siguiente codigo compile sin errores.

// Ejercicio 16
interface User {
  name: string;
  age: number;
  occupation: string;
}

interface Admin {
  name: string;
  age: number;
  role: string;
}

type Person = User | Admin;

const persons: Person[] = [
  {
    name: "Max Mustermann",
    age: 25,
    occupation: "Chimney sweep",
  },
  {
    name: "Jane Doe",
    age: 32,
    role: "Administrator",
  },
  {
    name: "Kate Müller",
    age: 23,
    occupation: "Astronaut",
  },
  {
    name: "Bruce Willis",
    age: 64,
    role: "World saver",
  },
];

function logPerson(person: Person) {
  console.log(` - ${person.name}, ${person.age}`);
}

console.log("Persons:");
persons.forEach(logPerson);

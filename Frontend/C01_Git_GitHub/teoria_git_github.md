# Git y GitHub - Teoría y Conceptos Fundamentales

## ¿Qué es Git?

**Git** es un sistema de control de versiones distribuido que permite realizar un seguimiento de los cambios en archivos y coordinar el trabajo entre múltiples personas. Es como un "historial de cambios" súper avanzado para tus proyectos.

### ¿Para qué se usa Git?
- **Seguimiento de cambios:** Ver qué cambios se hicieron, cuándo y quién los hizo
- **Volver a versiones anteriores:** Como un "Control+Z" avanzado para todo el proyecto
- **Trabajo colaborativo:** Múltiples personas pueden trabajar en el mismo proyecto sin pisarse
- **Ramas (branches):** Trabajar en nuevas características sin afectar el código principal
- **Respaldos distribuidos:** Cada copia es un respaldo completo

**Ejemplo:** Imagina que estás escribiendo un ensayo. Git te permitiría guardar cada versión (borrador 1, borrador 2, versión final), ver qué cambios hiciste entre versiones, y si trabajas con un compañero, combinar sus cambios con los tuyos sin perder trabajo.

## ¿Qué es GitHub?

**GitHub** es una plataforma en la nube que utiliza Git para almacenar y gestionar proyectos (repositorios). Es como "Google Drive para programadores", pero mucho más potente.

### ¿Para qué se usa GitHub?
- **Almacenamiento remoto:** Guardar tu código en la nube
- **Colaboración:** Trabajar en equipo en proyectos
- **Portafolio:** Mostrar tus proyectos públicamente
- **Gestión de proyectos:** Issues, pull requests, wikis
- **Integración continua:** Automatizar pruebas y despliegues
- **Redes sociales para desarrolladores:** Seguir proyectos y desarrolladores

## Conceptos Fundamentales

### Repositorio (Repository)
Un **repositorio** es como una carpeta de proyecto que contiene todos los archivos y el historial completo de cambios.

**Tipos:**
- **Local:** En tu computadora
- **Remoto:** En GitHub, GitLab, etc.

### Commit
Un **commit** es como una "fotografía" de tu proyecto en un momento específico. Cada commit tiene:
- Un mensaje descriptivo
- Un identificador único (hash)
- Información del autor
- Fecha y hora

**Ejemplo:**
```
commit a1b2c3d4
Author: Juan Pérez <juan@email.com>
Date: Mon Dec 4 14:30:00 2023
    
    Agregar función de login
```

### Working Directory, Staging Area y Repository

Git maneja tres "áreas" principales:

```
Working Directory  →  Staging Area  →  Repository
(Área de trabajo)     (Área temporal)   (Repositorio)
     |                      |               |
  Modificas            Preparas          Confirmas
  archivos             cambios           cambios
```

**Explicación:**
1. **Working Directory:** Donde trabajas y modificas archivos
2. **Staging Area:** Donde preparas los cambios que quieres confirmar
3. **Repository:** Donde se guardan permanentemente los commits

### Branch (Rama)
Una **rama** es una línea independiente de desarrollo. Te permite trabajar en nuevas características sin afectar el código principal.

```
main:     A -- B -- C -- F -- G
               \         /
feature:        D -- E --
```

**Ventajas:**
- Desarrollar características por separado
- Experimentar sin miedo
- Trabajo en paralelo de múltiples desarrolladores

### Remote (Remoto)
Un **remote** es una versión del repositorio almacenada en otro lugar (como GitHub).

**Remotos comunes:**
- **origin:** El repositorio principal (por defecto)
- **upstream:** El repositorio original (en forks)

## Flujo Básico de Trabajo

### 1. Configuración Inicial
```bash
# Configurar nombre y email
git config --global user.name "Tu Nombre"
git config --global user.email "tu@email.com"
```

### 2. Inicializar Repositorio
```bash
# Crear nuevo repositorio
git init mi-proyecto

# O clonar uno existente
git clone https://github.com/usuario/proyecto.git
```

### 3. Ciclo de Trabajo Básico
```bash
# 1. Modificar archivos (Working Directory)
# ... hacer cambios en archivos ...

# 2. Ver estado
git status

# 3. Agregar al staging area
git add archivo.txt
git add .  # Agregar todos los archivos

# 4. Confirmar cambios
git commit -m "Mensaje descriptivo"

# 5. Enviar a repositorio remoto
git push origin main
```

## Comandos Git Esenciales

### Comandos de Configuración
- **git config:** Configurar Git
- **git init:** Inicializar repositorio
- **git clone:** Clonar repositorio

### Comandos de Estado
- **git status:** Ver estado actual
- **git log:** Ver historial de commits
- **git diff:** Ver diferencias entre archivos

### Comandos de Cambios
- **git add:** Agregar archivos al staging area
- **git commit:** Confirmar cambios
- **git reset:** Deshacer cambios

### Comandos de Ramas
- **git branch:** Listar/crear ramas
- **git checkout:** Cambiar de rama
- **git merge:** Fusionar ramas

### Comandos Remotos
- **git remote:** Gestionar remotos
- **git push:** Enviar cambios
- **git pull:** Recibir cambios
- **git fetch:** Descargar cambios sin fusionar

## GitHub - Funcionalidades Principales

### Repositorios
**Públicos:** Cualquiera puede verlos
**Privados:** Solo personas autorizadas

### Issues
Sistema de seguimiento de errores y tareas.
```
Título: Error en login
Descripción: Al ingresar usuario incorrecto, la página se rompe
Etiquetas: bug, urgente
Asignado a: @desarrollador1
```

### Pull Requests (PR)
Propuesta de cambios que permite:
- Revisión de código
- Discusión de cambios
- Pruebas automáticas
- Fusión controlada

### Fork
Crear una copia personal de un repositorio de otra persona.
```
Repositorio original → Fork → Modificar → Pull Request
```

### GitHub Pages
Servicio gratuito para hospedar sitios web directamente desde un repositorio.

### Actions
Automatización de tareas (CI/CD):
- Ejecutar pruebas automáticamente
- Desplegar aplicaciones
- Revisar código

## Flujo de Trabajo Colaborativo

### Flujo GitHub (GitHub Flow)
1. **Crear rama** para nueva característica
2. **Hacer commits** en la rama
3. **Abrir Pull Request**
4. **Revisar código** con el equipo
5. **Fusionar** a rama principal
6. **Eliminar** rama de característica

### Flujo Git (Git Flow)
Más complejo, con ramas específicas:
- **main/master:** Código en producción
- **develop:** Rama de desarrollo
- **feature:** Nuevas características
- **release:** Preparación de lanzamientos
- **hotfix:** Correcciones urgentes

## Buenas Prácticas

### Commits
✅ **Buenos commits:**
```
git commit -m "Agregar validación de email en formulario registro"
git commit -m "Corregir error de división por cero en calculadora"
```

❌ **Malos commits:**
```
git commit -m "fix"
git commit -m "cambios varios"
git commit -m "asdfgh"
```

### Mensajes de Commit
**Estructura recomendada:**
```
Tipo: Descripción breve (máximo 50 caracteres)

Explicación detallada opcional (máximo 72 caracteres por línea)

- Detalle 1
- Detalle 2
```

**Tipos comunes:**
- **feat:** Nueva característica
- **fix:** Corrección de error
- **docs:** Documentación
- **style:** Formato, espacios (sin cambio de lógica)
- **refactor:** Refactorización de código
- **test:** Agregar o corregir pruebas

### Estructura de Proyecto en GitHub

```
mi-proyecto/
├── README.md          # Descripción del proyecto
├── LICENSE           # Licencia del software
├── .gitignore        # Archivos a ignorar
├── package.json      # Dependencias (si es Node.js)
├── src/              # Código fuente
├── docs/             # Documentación
└── tests/            # Pruebas
```

### README.md
Archivo principal que debe incluir:
```markdown
# Nombre del Proyecto

Descripción breve del proyecto

## Instalación
```bash
npm install
```

## Uso
```bash
npm start
```

## Contribuir
1. Fork el proyecto
2. Crear rama feature
3. Commit cambios
4. Push a la rama
5. Abrir Pull Request
```

## Herramientas y Interfaces

### Línea de Comandos (CLI)
```bash
git status
git add .
git commit -m "mensaje"
git push
```

### Interfaces Gráficas
- **GitHub Desktop:** Cliente oficial de GitHub
- **GitKraken:** Cliente visual profesional
- **SourceTree:** Cliente gratuito de Atlassian
- **VS Code:** Integración Git incorporada

### Extensiones y Plugins
- **Git Lens (VS Code):** Información detallada de Git
- **GitHub CLI:** Herramientas de línea de comandos para GitHub
- **Hub:** Extensión de Git para GitHub

## Resolución de Conflictos

### ¿Qué es un Conflicto?
Cuando dos personas modifican la misma línea de código y Git no puede fusionar automáticamente.

### Ejemplo de Conflicto
```
<<<<<<< HEAD
console.log("Hola Mundo");
=======
console.log("Hello World");
>>>>>>> feature-branch
```

### Resolución
1. **Identificar** archivos en conflicto
2. **Editar** archivos para resolver diferencias
3. **Eliminar** marcadores de conflicto
4. **Agregar** archivos resueltos
5. **Hacer commit** de la resolución

## Comandos de Emergencia

### Deshacer Cambios
```bash
# Deshacer cambios no confirmados
git checkout -- archivo.txt

# Deshacer último commit (manteniendo cambios)
git reset --soft HEAD~1

# Deshacer último commit (eliminando cambios)
git reset --hard HEAD~1
```

### Recuperar Trabajo Perdido
```bash
# Ver todos los commits (incluso eliminados)
git reflog

# Recuperar commit específico
git cherry-pick commit-hash
```

### Limpiar Repositorio
```bash
# Ver archivos que se eliminarían
git clean -n

# Eliminar archivos no rastreados
git clean -f
```

## Glosario Rápido

| Término | Definición |
|---------|------------|
| **Repository** | Carpeta de proyecto con historial |
| **Commit** | Snapshot de cambios |
| **Branch** | Línea de desarrollo independiente |
| **Merge** | Fusionar ramas |
| **Clone** | Copiar repositorio remoto |
| **Fork** | Copia personal de repositorio ajeno |
| **Pull Request** | Propuesta de cambios |
| **Issue** | Reporte de problema o tarea |
| **Remote** | Repositorio en otro lugar |
| **Staging Area** | Área temporal para cambios |

---

**Recuerda:** Git y GitHub son herramientas poderosas que requieren práctica. Empieza con lo básico y gradualmente incorpora funcionalidades más avanzadas. ¡La clave está en practicar con proyectos reales!
# 🎓 Sistema de Gestión de Estudiantes

Aplicación de consola desarrollada en **C#** con Visual Studio Community 2022, enfocada en la gestión de estudiantes: registro, almacenamiento de notas, cálculo de promedios y clasificación de rendimiento académico. El proyecto está diseñado para aplicar principios fundamentales de la **Programación Orientada a Objetos (POO)** y reforzar buenas prácticas como validaciones de entrada, organización de clases y estructura modular del código.

---

## 📌 Funcionalidades

- Registro de estudiantes ingresando:
  - Nombre (solo texto, validado)
  - Edad (entre 1 y 60)
  - Código del estudiante (único)
  - Tres notas entre 0 y 5

- Cálculo automático del promedio general del estudiante

- Clasificación de rendimiento académico:
  - `≥ 4.5` → Excelente
  - `≥ 3.5` → Bueno
  - `≥ 2.5` → Regular
  - `< 2.5` → Deficiente

- Informe completo en consola con todos los datos del estudiante

- Validaciones de entrada para evitar errores en tiempo de ejecución

---

## 🧠 Estructura del código

- `Persona` *(clase base)*: contiene propiedades `Nombre` y `Edad`
- `Estudiante` *(clase derivada)*: hereda de `Persona` e incluye `Codigo` y `ListaDeNotas`
- `Program` *(clase principal)*: contiene lógica de menú, registro, informes y validaciones auxiliares

---

## 🛠️ Tecnologías

- Lenguaje: **C# 12**
- Framework: **.NET 9.0**
- IDE: **Visual Studio 2022**
- Plataforma: **Consola de Windows**
- Control de versiones: **Git**

---

## 🚀 Cómo ejecutar

1. Clona este repositorio  
   `git clone https://github.com/Fabrizio-Franco1405/Gestion-de-Estudiantes.git`

2. Abre el proyecto con Visual Studio 2022

3. Ejecuta en modo consola (`Ctrl + F5`) o compílalo para generar el `.exe`

---

## 📁 Estructura del proyecto

```
Gestion-de-Estudiantes/
├── 
├── Gestion-de-Estudiantes.sln
├── Gestion-de-Estudiantes/
|   ├── bin/
│   ├── obj/
|   ├── .gitignore
│   ├── Gestion-de-Estudiantes.csproj
│   ├── Program.cs
```

---

## 🧪 Ejemplo de uso

```plaintext
1. Registrar Estudiante
2. Mostrar Informes de Estudiantes
3. Salir

> Nombre: Ana Torres
> Edad: 20
> Código: 2023001
> Notas: 4 3 5

→ Promedio: 4.00
→ Rendimiento: Bueno


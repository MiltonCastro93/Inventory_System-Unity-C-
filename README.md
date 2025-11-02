# 🗂️ Sistema de Inventario – Unity 🗂️

> Proyecto académico que implementa un **sistema de inventario simple** en **Unity 2024** utilizando **C#**, con **assets gratuitos de la Unity Asset Store** para ítems y UI.  
> El proyecto aplica **algoritmos clásicos de ordenamiento y búsqueda**, específicamente **Bubble Sort** y **búsqueda lineal/binaria**, para la gestión de los objetos del inventario.

---

## 🧠 Descripción general

Este prototipo permite al jugador **almacenar, ordenar y buscar objetos** dentro de un inventario limitado.  
El sistema está pensado como **base para juegos de supervivencia o RPG**, donde el jugador necesita **gestionar recursos y herramientas** de manera eficiente.  

El inventario soporta:

- **Añadir y eliminar ítems**  
- **Ordenar ítems por nombre, tipo o valor** usando **Bubble Sort**  
- **Buscar ítems específicos** mediante **búsqueda lineal** o **búsqueda binaria**  

---

## ⚙️ Detalles técnicos

| Elemento | Descripción |
|-----------|--------------|
| 🧩 **Motor** | Unity 2024 (versión LTS) |
| 💻 **Lenguaje** | C# |
| 🎮 **Tipo de proyecto** | Académico / Prototipo jugable |
| 🎨 **Estética visual** | Assets de Unity Store, simple y funcional |
| 🧱 **Plataforma** | Windows / Mac |
| 💾 **Control de versiones** | Git / GitHub |
| 👤 **Desarrollador** | Milton Castro |

---

## 🔧 Funcionamiento del sistema

1. **Añadir ítems:**  
   Cada objeto tiene propiedades como `nombre`, `tipo` y `valor`. El jugador puede agregar objetos al inventario hasta llenar su capacidad máxima.

2. **Ordenamiento (Bubble Sort):**  
   - Recorre el inventario comparando objetos adyacentes.  
   - Si un objeto está “mal ubicado” según el criterio (por ejemplo, alfabéticamente), se intercambia con el siguiente.  
   - Repite el proceso hasta que no se requieran más intercambios.  
   - Resultado: **el inventario queda ordenado de menor a mayor según el criterio elegido**.  

3. **Búsqueda de ítems:**  
   - **Lineal:** recorre cada ítem hasta encontrar el deseado.  
   - **Binaria:** si el inventario está ordenado, divide la lista y busca el ítem en la mitad correspondiente repetidamente hasta encontrarlo o agotar las opciones.  
   - Resultado: **rápida localización de objetos dentro del inventario**.

4. **Visualización:**  
   - Interfaz simple que muestra **nombre, tipo y cantidad** de cada objeto.  
   - Los objetos se muestran en **grillas o listas** con iconos de assets descargados de la Unity Asset Store.  

---

## 🖼️ Capturas del proyecto

_(Ejemplos de UI y visualización de inventario con assets gratuitos)_  

![Inventario 1](https://github.com/MiltonCastro93/Inventario_Unity/blob/main/Inventario1.png)  
> *Vista del inventario con ordenamiento aplicado y búsqueda de ítems.*

---

## 🧩 Arquitectura del código

- **InventoryItem.cs** → Clase que define las propiedades de cada ítem.  
- **InventoryManager.cs** → Manejo del inventario: agregar, eliminar, ordenar y buscar objetos.  
- **UIInventory.cs** → Control de la interfaz gráfica del inventario.  
- **SortAlgorithms.cs** → Implementación de **Bubble Sort** y funciones de comparación.  
- **SearchAlgorithms.cs** → Implementación de búsqueda lineal y binaria.  

---

## 🎯 Propósito académico

El proyecto busca:  

- Comprender la **implementación de algoritmos clásicos** en un contexto de desarrollo de juegos.  
- Aplicar **estructuras de datos básicas** para gestión de inventario.  
- Integrar **assets gratuitos de Unity** y mostrar objetos en una UI funcional.  
- Proporcionar una **base sólida para sistemas más complejos** en futuros proyectos de juegos.  

---

## 📜 Licencia

Proyecto **académico**, sin fines comerciales.  
Todos los recursos visuales son **de libre licencia de la Unity Asset Store**.

---

## ✨ Cierre

> *“Un inventario ordenado no solo facilita la gestión de recursos, sino que permite al jugador tomar decisiones rápidas y eficientes.”*  
> — Milton Castro

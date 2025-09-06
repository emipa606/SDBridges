# GitHub Copilot Instructions for [sd] Bridges (Continued) Mod Development

Welcome to the development guide for the [sd] Bridges (Continued) mod for RimWorld, developed in C#. This document provides an overview of the mod, key features, coding conventions, XML integration, Harmony patching, and suggestions for using GitHub Copilot effectively.

## Mod Overview and Purpose

The [sd] Bridges (Continued) mod enhances RimWorld by providing extended functionality for terrain manipulation and bridge creation over water. It builds on the original mod by sulusdacors, featuring updates such as moving water support and new bridge types.

**Purpose**: 
- Expand base-building options in RimWorld, allowing for more creative and strategic layouts.
- Introduce new research projects and materials to offer players unique gameplay mechanics.

## Key Features and Systems

- **Bridge Construction**:
  - Implement three research projects: bridges, drawbridge, and terraforming.
  - Provide different types of bridges, including linkable wood and pontoon bridges, as well as double-wide drawbridges.
  - Allow foundation placement for building on shallow water types.
  
- **Terraforming**:
  - Introduce terraforming to change terrain from solid ground to deep water and vice versa.
  - Create a dedicated terraforming category in the architect menu.

- **Materials & Recipes**:
  - Add two new materials, foundation material and pontoons, with associated recipes available at the stonecutter and machining tables.

## Coding Patterns and Conventions

- **Organization**:
  - Follow a clear file and class structure to separate different functionality, such as different types of bridges and terrain classes.
  
- **Naming Conventions**:
  - Use `PascalCase` for class names (e.g., `Building_sd_bridges_drawbridge_up`).
  - Use `camelCase` for method names and local variables.
  
- **Abstraction and Inheritance**:
  - Utilize abstract classes to define base behavior for bridge-related classes (e.g., `Building_sd_bridges_basedrawbridge`).

## XML Integration

- Use XML for defining new terrain and building types under `terrainDefs` and `thingDefs`.
- Define complex multi-step recipes and research requirements in XML to integrate with the existing game structures.
- Ensure compatibility with other mods through careful use of XML Patch Operations (PatchOps).

## Harmony Patching

- Given that some core game mechanics are unmodifiable directly, use Harmony for runtime code alterations.
- Create patches where necessary to enable or adjust game behaviors that are not accessible through normal modding methods.

## Suggestions for Copilot

- **Bridge Mechanics**:
  - Suggest functions for calculating appropriate terrain placement for bridges and platforms.
  - Enhance PlaceWorker logic for correct foundation and bridge placement in-game.

- **Terraforming Logic**:
  - Propose methods for unique terrain transitions and ensure seamless integration with existing game visuals.
  
- **Performance Optimizations**:
  - Identify opportunities to streamline large computations, such as the work intensive processes of terraforming.
  - Assist in writing efficient bulk recipe processing functions.

- **Testing and Compatibility**:
  - Suggest unit tests to ensure newly proposed game actions behave as expected.
  - Provide insights on potential conflicts with other mods or game updates.

With these guidelines, GitHub Copilot can be leveraged effectively to maintain and extend the [sd] Bridges (Continued) mod's functionality, ensuring a smooth development process and high-quality gaming experience.

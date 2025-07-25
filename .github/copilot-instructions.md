# GitHub Copilot Instructions for RimWorld Modding Project

## Mod Overview and Purpose

This project is a mod for RimWorld that enhances the bridge-building mechanics in the game. It introduces various new bridge types and expands the terrain manipulation capabilities of players, allowing them to channel water flows and build functional and aesthetic bridge structures over different types of water and terrain.

## Key Features and Systems

- **Multiple Bridge Types**: The mod provides several bridge types, including drawbridges (both single and double), pontoon bridges, and various other forms compatible with different terrain conditions.

- **Terrain Manipulation**: Enhanced terrain transformation mechanics allow for changing water and marshland into walkable or buildable surfaces, providing strategic options and expansion opportunities.

- **Place Workers**: Custom place workers ensure that the bridges and terrain manipulation structures can only be placed on appropriate surfaces, adding realistic constraints and gameplay depth.

## Coding Patterns and Conventions

- **Class Hierarchy**: The mod follows a clear class hierarchy based on the functionalities:
  - Base class `Building_sd_bridges_basedrawbridge` contains shared behaviors for drawbridges.
  - Derived classes such as `Building_sd_bridges_doubledrawbridge_down` and `Building_sd_bridges_drawbridge_up` extend the base functionality to provide specific types of drawbridges.

- **Naming Conventions**: Class and method names follow the PascalCase convention, ensuring consistency and readability. The prefix `Building_sd_bridges_` or `PlaceWorker_` clearly denotes the purpose and category of each class.

- **Helper Classes**: Utility classes like `Util_sd_bridges` and `Textures` are used to encapsulate shared logic and resources, promoting code reuse and modular design.

## XML Integration

The XML files are essential to the mod, as they define the game's content to be loaded. While there were issues parsing the XML in this summary, ensure that each XML file is correctly formatted to tie the C# code with the game assets, such as textures, structure definitions, and placement rules. Regularly validate your XML files against RimWorld’s schema.

## Harmony Patching

The mod does not currently list specific Harmony patches, which suggests it either does not alter existing game functionality or that Harmony patches are planned but not yet implemented.

- **Suggestions for Harmony**: Consider using Harmony to apply patches for methods within the base game that interact with bridge placement or terrain manipulation. This would extend compatibility and mod extensibility without altering base game timings or behaviors directly.

## Suggestions for Copilot

To effectively utilize GitHub Copilot in this project:

- **Use Copilot for Code Suggestions**: When writing new classes or methods, such as additional bridge types or new place workers, leverage Copilot to suggest boilerplate code based on existing patterns in the project.

- **Generate XML Configurations**: While Copilot struggled with XML in this summary, it can successfully suggest new XML elements based on existing game data and previous XML structures once addressed.

- **Refactor and Optimize**: Use Copilot to refactor existing code for improved clarity and performance. It can assist in identifying patterns and provide suggestions to streamline complex logic.

- **Documenting Code**: Prompt Copilot to assist in generating comments and documentation, ensuring each class and method has clear explanations about its behavior and purpose.

By following these guidelines and leveraging Copilot effectively, you can enhance your mod development process, creating a robust and well-integrated RimWorld mod.

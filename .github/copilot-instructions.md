# GitHub Copilot Instructions for [sd] Bridges (Continued) RimWorld Mod

## Mod Overview and Purpose
[sd] Bridges (Continued) is an update of the original sulusdacors mod, extending the game's bridge-building capabilities by adding support for moving water, double, triple, and quad-wide drawbridges, and allowing drawbridge actions to be performed by pawns instead of instantly. The mod also introduces terraforming features to change terrain from solid ground to deep water and vice versa.

## Key Features and Systems
- **Drawbridges**: Includes single, double, triple, and quad-wide drawbridges.
- **Pontoon Bridges**: Allows building bridges on water using pontoons.
- **Terraforming**: Enables players to change terrain from solid ground to deep water and vice versa through a multi-step process.
- **Foundation and Platform**: Adds foundation and platform structures for building on shallow water and constructing permanent structures.
- **Material Recipes**: Includes recipes for foundation material and pontoons at the stonecutter and machining table.

## Coding Patterns and Conventions
- **Namespaces**: Use clear and descriptive namespaces to organize code. For example, `SDBridges.Buildings` for all bridge-related classes.
- **Class Naming**: Follow PascalCase naming conventions for classes, e.g., `Building_DoubleDrawbridgeDown`.
- **Method Naming**: Use camelCase for method names, e.g., `spawnDrawbridge`.
- **Documentation**: Include XML documentation for public classes and methods to facilitate understanding and maintenance.
- **Error Handling**: Implement robust error handling and logging to assist with debugging.

## XML Integration
- **Def Files**: Ensure all XML def files are correctly formatted and follow RimWorld's XML standards.
- **Def Types**: Use appropriate def types for different elements, such as `ThingDef`, `JobDef`, and `DesignationCategoryDef`.
- **Mod Compatibility**: Maintain compatibility with other mods by using patch operations and ensuring that the mod does not interfere with AI behavior.

## Harmony Patching
- **Patch Operations**: Use Harmony patching to modify existing RimWorld code without altering the original codebase.
- **Patch Naming**: Name patch methods clearly to indicate their purpose, e.g., `Patch_Building_Drawbridge_Destruction`.
- **Patch Placement**: Place patch methods in separate classes to keep the code organized and maintainable.

## Suggestions for Copilot
1. **Class Creation**: When creating new classes for buildings or other structures, consider using existing classes as templates.
2. **Method Implementation**: For implementing methods, start with the necessary parameters and return types, then fill in the logic.
3. **XML Defs**: When creating or modifying XML def files, ensure that all required attributes and elements are included.
4. **Patch Operations**: When writing patch operations, focus on identifying the correct method and parameters to patch.
5. **Documentation**: Include XML comments for all public classes and methods to ensure clarity and maintainability.

## Example Usage
### Creating a New Building Class
csharp
namespace SDBridges.Buildings
{
    public class Building_DoubleDrawbridgeDown : Building_Drawbridge
    {
        public override void SpawnSetup(Map map, bool respawningAfterLoad)
        {
            base.SpawnSetup(map, respawningAfterLoad);
            // Additional setup code
        }

        public override void Destroy(DestroyMode mode = DestroyMode.Vanish)
        {
            base.Destroy(mode);
            // Additional cleanup code
        }
    }
}


### Example XML Def File
xml
<ThingDef>
    <defName>sd_bridge_double_down</defName>
    <label>Double-Drawbridge (Down)</label>
    <description>A double-width drawbridge that can be raised and lowered.</description>
    <thingClass>Building_Drawbridge</thingClass>
    <category>Building</category>
    <costList>
        <Steel>20</Steel>
        <Wood>20</Wood>
    </costList>
    <statBases>
        <MaxHP>200</MaxHP>
    </statBases>
</ThingDef>


### Harmony Patch Example
csharp
using HarmonyLib;
using RimWorld;
using System.Reflection;

namespace SDBridges.Patches
{
    [HarmonyPatch(typeof(Building_Drawbridge), nameof(Building_Drawbridge.Destroy))]
    public static class Patch_Building_Drawbridge_Destruction
    {
        public static void Postfix(Building_Drawbridge __instance, DestroyMode mode)
        {
            // Additional cleanup code after destruction
        }
    }
}


## Conclusion
By following these guidelines and utilizing GitHub Copilot, you can enhance the modding experience for [sd] Bridges (Continued) and ensure that the mod remains well-organized, maintainable, and compatible with other mods.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.


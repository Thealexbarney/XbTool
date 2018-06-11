# Scripts

Offsets to the section data are always relative to the start of the section header.

## Header

|Field|Offset|Length|Contents|
|:-:|:-:|:-:|:-:|
|ID|0|4|"SB  "|
|Version|4|1|Assumed|
|Flags|6|1||
|Is Loaded|7|1|Set when the script is loaded by the VM|
|Code Offset|8|4||
|ID Pool Offset|12|4||
|Int Pool Offset|16|4||
|Fixed Pool Offset|20|4||
|String Pool Offset|24|4||
|Function Pool Offset|28|4||
|Plugin Imports Offset|32|4||
|OC Imports Offset|36|4||
|Function Imports Offset|40|4||
|Static Variables Offset|44|4||
|Local Pool Offset|48|4||
|System Attribute Pool Offset|52|4||
|User Attribute Pool Offset|56|4||
|Debug Symbols Offset|60|4||

## Code

|Field|Offset|Length|Contents|
|:-:|:-:|:-:|:-:|
|Offset|0|4|Offset to data|
|Unknown|4|4|Always 0?|
|Length|8|4|Length of data|

## ID Pool
Contains a list of the IDs of all the objects in the script. 

|Field|Offset|Length|Contents|
|:-:|:-:|:-:|:-:|
|Offset|0|4|Offset to data|
|Count|4|4|Number of strings in the section|
|Size|8|4|Size in bytes of elements in the offset array|
|Offsets|`Offset`|`Count` * `Size`|Array of offsets to strings relative to the start of this array.|
|IDs|Varies|Varies|Null-terminated string data|

## Int Pool
Contains a list of 32-bit integers used in the script.

|Field|Offset|Length|Contents|
|:-:|:-:|:-:|:-:|
|Offset|0|4|Offset to data|
|Count|4|4|Number of elements in the section|
|Values|`Offset`|`Count` * 4|Array of integers|

## Fixed Pool
Contains a list of 32-bit floating-point values used in the script.

|Field|Offset|Length|Contents|
|:-:|:-:|:-:|:-:|
|Offset|0|4|Offset to data|
|Count|4|4|Number of elements in the section|
|Values|`Offset`|`Count` * 4|Array of floating-point numbers|

## String Pool
Contains a list of strings used in the script. 

|Field|Offset|Length|Contents|
|:-:|:-:|:-:|:-:|
|Offset|0|4|Offset to data|
|Count|4|4|Number of strings in the array|
|Size|8|4|Size in bytes of elements in the offset array|
|Offsets|`Offset`|`Count` * `Size`|Array of offsets to strings relative to the start of this array.|
|Strings|Varies|Varies|Null-terminated string data|

## Function Pool
Contains a list of local functions in the script.

|Field|Offset|Length|Contents|
|:-:|:-:|:-:|:-:|
|Offset|0|4|Offset to function data array|
|Count|4|4|Number of elements in the array|
|Size|8|4|Size in bytes of elements in the array|
|Function Data|`Offset`|`Count` * `Size`|Array of function definitions|

### Function
|Field|Offset|Length|Contents|
|:-:|:-:|:-:|:-:|
|Name Index|0|2|Index in the ID Pool of the function's name|
|Field 2|2|2||
|Field 4|4|2||
|Field 6|6|2||
|Local Pool Index|8|2||
|Field 10|10|2||
|Start|12|4|Code address of the function start|
|End|16|4|Code address of the function end|

## Plugin Imports
Contains a list of imported plugin functions.

|Field|Offset|Length|Contents|
|:-:|:-:|:-:|:-:|
|Offset|0|4|Offset to data|
|Count|4|4|Number of elements in the array|
|Size|8|4|Size in bytes of elements in the array|
|Values|`Offset`|`Count` * `Size`|Array of plugin functions|

### Plugin Import
|Field|Offset|Length|Contents|
|:-:|:-:|:-:|:-:|
|Plugin Name|0|2|Index in the ID Pool of the plugin's name|
|Function Name|0|2|Index in the ID Pool of the function's name|

## OC Imports
Contains a list of imported OCs.

|Field|Offset|Length|Contents|
|:-:|:-:|:-:|:-:|
|Offset|0|4|Offset to data|
|Count|4|4|Number of elements in the array|
|Size|8|4|Size in bytes of elements in the array|
|OC Names|`Offset`|`Count` * `Size`|Array of imported OC name IDs|

## Function Imports
Contains a list of imported functions from other scripts.

|Field|Offset|Length|Contents|
|:-:|:-:|:-:|:-:|
|Offset|0|4|Offset to data|
|Count|4|4|Number of elements in the array|
|Size|8|4|Size in bytes of elements in the array|

## Static Variables
Contains a list of global script variables.

|Field|Offset|Length|Contents|
|:-:|:-:|:-:|:-:|
|Offset|0|4|Offset to data|
|Count|4|4|Number of elements in the array|
|Objects|`Offset`|`Count` * 12|Global objects|

### Object

|Field|Offset|Length|Contents|
|:-:|:-:|:-:|:-:|
|Type|0|1|The object type|
|Length|2|2|Used for objects like arrays|
|Value|4|4|The object value|
|Field 8|8|4|Only exists in 64-bit scripts. Used for pointer storage space|

## Local Pool
Contains local variables used for individual functions.

|Field|Offset|Length|Contents|
|:-:|:-:|:-:|:-:|
|Offset|0|4|Offset to data|
|Count|4|4|Number of elements in the array|
|Size|8|4|Size in bytes of elements in the offset array|
|Offsets|`Offset`|`Count` * `Size`|Array of offsets to the function stacks relative to the start of this array.|

### Function Stack

|Field|Offset|Length|Contents|
|:-:|:-:|:-:|:-:|
|Offset|0|4|Offset to data|
|Count|4|4|Number of elements in the array|
|Objects|`Offset`|`Count` * 12|Array of local objects|

## System Attribute Pool
Contains a list of system attributes.

|Field|Offset|Length|Contents|
|:-:|:-:|:-:|:-:|
|Offset|0|4|Offset to data|
|Count|4|4|Number of elements in the array|
|Size|8|4|Size in bytes of elements in the array|
|OC Names|`Offset`|`Count` * `Size`|Array of attribute name IDs|

## User Attribute Pool
Contains a list of user attributes.

|Field|Offset|Length|Contents|
|:-:|:-:|:-:|:-:|
|Offset|0|4|Offset to data|
|Count|4|4|Number of elements in the array|
|Size|8|4|Size in bytes of elements in the array|
|OC Names|`Offset`|`Count` * `Size`|Array of attribute name IDs|

## Debug Symbols (Optional)
Contains debug symbols for the script.

|Field|Offset|Length|Contents|
|:-:|:-:|:-:|:-:|
|Static Variable Symbols Offset|0|4|Symbols for global variables|
|Local Variable Symbols Offset|4|4|Symbols for local variables|
|Argument Symbols Offset|8|4|Symbols for function arguments|
|Filename Symbols Offset|12|4|A list of files used in compiling the script|
|Line Info Symbols Offset|16|4|Contains line number information|


# PainScript

A language pain to code in

## Running Compiler

```./painscript <input file location> <output file location>```

Eg. ```./painscript program.ps output.ps```

## Syntax

`>`: Move the pointer left
`<`: Move the pointer right
`+`: Increase the value of the cell which pointer is pointing at
`-`: Decrease the value of the cell which pointer is pointing at
`'`: Print the value's translation in letters to the console(lowercase)
`"`: Print the value's translation in letters to the console(UPPERCASE)
`]`: Print the value's translation in numbers to the console
`[`: Print the value's translation in special chracters to the console

`Comments`: All characters which don't interfere with the syntax.

## Translation

| Value | in Upper Letter | in Lower Letter | in Number | in special character |
| ----- | --------------- | --------------- | --------- | -------------------- |
| 0     | {SPACE}         | {SPACE}         | 0         | ~                    |
| 1     | A               | a               | 1         | !                    |
| 2     | B               | b               | 2         | @                    |
| 3     | C               | c               | 3         | #                    |
| 4     | D               | d               | 4         | $                    |
| 5     | E               | e               | 5         | %                    |
| 6     | F               | f               | 6         | ^                    |
| 7     | G               | g               | 7         | &                    |
| 8     | H               | h               | 8         | *                    |
| 9     | I               | i               | 9         | (                    |
| 10    | J               | j               | {ERROR}   | )                    |
| 11    | K               | k               | {ERROR}   | -                    |
| 12    | L               | l               | {ERROR}   | _                    |
| 13    | M               | m               | {ERROR}   | +                    |
| 14    | N               | n               | {ERROR}   | =                    |
| 15    | O               | o               | {ERROR}   | \`                   |
| 16    | P               | p               | {ERROR}   | \[                   |
| 17    | Q               | q               | {ERROR}   | \]                   |
| 18    | R               | r               | {ERROR}   | {                    |
| 19    | S               | s               | {ERROR}   | }                    |
| 20    | T               | t               | {ERROR}   | \|                   |
| 21    | U               | u               | {ERROR}   | \                    |
| 22    | V               | v               | {ERROR}   | ;                    |
| 23    | W               | w               | {ERROR}   | :                    |
| 24    | X               | x               | {ERROR}   | "                    |
| 25    | Y               | y               | {ERROR}   | '                    |
| 26    | Z               | z               | {ERROR}   | <                    |
| 27    | {ERROR}         | {ERROR}         | {ERROR}   | >                    |
| 28    | {ERROR}         | {ERROR}         | {ERROR}   | ,                    |
| 29    | {ERROR}         | {ERROR}         | {ERROR}   | .                    |
| 30    | {ERROR}         | {ERROR}         | {ERROR}   | ?                    |
| 31    | {ERROR}         | {ERROR}         | {ERROR}   | /                    |
| 32    | {ERROR}         | {ERROR}         | {ERROR}   | {NEW LINE}           |

**Numbers past this will drop an error**
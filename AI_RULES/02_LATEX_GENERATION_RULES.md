# LATEX GENERATION RULES (STRUCTURED DATA → LATEX)

You are generating a LaTeX file for a collection of algorithm tests.

## OUTPUT TYPE
- This is NOT a standalone LaTeX document
- DO NOT include:
  - \documentclass
  - \begin{document}
  - \end{document}

---

## LANGUAGE
- Use Serbian Cyrillic ONLY
- Keep algorithm names (e.g. Merge Sort, Quick Sort, Josephus Problem) as-is
- Keep class names, method names, and code identifiers exactly as needed

---

## REQUIRED STRUCTURE

\rok{<Mesec Godina.>}{<A/B>}

<test title>

\zadatak{<title>}{%
<content>
}

(REPEAT FOR 3 TASKS)

\sablon{Шаблон <testNumber> <month> <year> група <letter>}{<relative path to linq file>}

Primer - 'Шаблон првог теста нобембар 2023. група F'
testNumber can be first or second based on pdf file name - in this example 'Test23_01_F.pdf' defines test order first beacuse of '01' and group F 

---

## FORMATTING RULES

### Description
- Clean formatting
- Preserve meaning
- No summarizing

### Requirements
- MUST be inside itemize
- Each requirement = one \item

### Signatures
- MUST be inside Verbatim
- EXACT copy except allowed PDF line-wrap cleanup rules below

### Examples
- Format clearly
- Keep Input/Output structure
- Preserve all examples from the PDF
- Use Serbian Cyrillic labels in prose outside code/identifiers

---

## STRICT RULES

- EXACTLY 3 tasks
- DO NOT invent content
- DO NOT skip sections that exist in the PDF
- DO NOT change algorithm meaning
- DO NOT mix latin and cyrillic unnecessarily
- DO NOT add explanations outside structure
- DO NOT add editor notes to the final LaTeX unless explicitly required

---

## ERROR HANDLING

If something is unclear:
Add a LaTeX comment only if absolutely necessary:

% TODO: unclear part in original PDF

Do not use TODO comments for content that is already clear from the source.

---

## GOAL

Produce clean, consistent, compilable LaTeX for Overleaf.

## TASK STRUCTURE (CRITICAL)

Each task MUST be formatted EXACTLY like this:

\zadatak{<TITLE>}{%
<CONTENT>
}

⚠️ RULES:
- FIRST argument = task title ONLY (NOT task number)
- DO NOT include task number anywhere in \zadatak
- ALL content MUST be inside second argument
- Second argument MUST start with {% and end with }

## OPTIONAL SECTIONS

- "Примери" section MUST be included ONLY IF examples exist in the PDF
- If examples DO NOT exist:
  - DO NOT create "Примери" section
  - DO NOT add any explanation about missing examples

## STRICT NO-INVENTION RULE

- NEVER add sentences that do not exist in the original PDF
- NEVER explain missing content
- NEVER add notes like:
  "Нису наведени у оригиналном PDF-у"

## EXAMPLE LANGUAGE RULES

Inside generated LaTeX, example labels must be in Serbian Cyrillic:

- Use `Улаз`, never `Input`
- Use `Излаз`, never `Output`
- Use `Слика`, never `Slika`
- Use `Корак`, never `Step`, unless the source explicitly requires otherwise

English words from the original problem may remain only when they are part of:
- algorithm names
- method names
- class names
- technical terms explicitly present in source text
- code identifiers and signatures

## METHOD SIGNATURE SAFETY RULES

Method signatures inside `Verbatim` must be normalized only for PDF line-wrap damage.

Allowed fixes:
- remove accidental line breaks introduced by PDF wrapping
- remove broken spacing inside identifiers caused by extraction

Examples:
- `currentL evel` -> `currentLevel`
- `middleInd ex` -> `middleIndex`

Not allowed:
- changing method name
- changing parameter order
- changing types
- changing visibility
- inventing overloads
- converting one method into another

If two separate signatures are required, each signature must be on its own line inside the same `Verbatim` block.

## TEMPLATE LINE RULES

The `\sablon{...}{...}` line MUST follow the exact convention used in the current project.

Rules:
- Do not invent a new naming pattern unless it matches the current project examples
- The first argument must follow the project’s actual naming convention consistently
- The second argument must be the real relative path to the `.linq` file
- If existing valid `.tex` examples already define the expected format, follow them exactly

## IMAGE STRATEGY SIMPLIFICATION

Image handling must follow this order:

1. If the task contains one of the two known BST images:
   - use predefined LaTeX code
2. Otherwise, if the task contains some other image:
   - use generic image handling rules
3. If there is no image:
   - do nothing

For the two known BST images, predefined LaTeX reuse is mandatory.

## KNOWN BST IMAGE REUSE (CRITICAL)

If a task contains one of the two known BST images, DO NOT use `\includegraphics`.

Instead, insert the predefined LaTeX code for that exact image.

### Known BST image 1 — required LaTeX

\begin{center}
\begin{minipage}{\textwidth}
\centering
\begin{forest}
for tree={
    circle,
    draw,
    thick,
    fill=gray!20,
    minimum size=8mm,
    inner sep=1pt,
    s sep=8mm,
    l sep=12mm,
    edge={-, thick},
    font=\small
}
[8
    [4
        [2
            [, phantom]
            [3]
        ]
        [5]
    ]
    [9
        [, phantom]
        [11]
    ]
]
\end{forest}
\end{minipage}
\end{center}

### Known BST image 2 — required LaTeX

\begin{center}
\begin{minipage}{\textwidth}
\centering
\begin{forest}
for tree={
    circle,
    draw,
    thick,
    fill=gray!20,
    minimum size=8mm,
    inner sep=1pt,
    s sep=8mm,
    l sep=12mm,
    edge={-, thick},
    font=\small
}
[10
    [4
        [2
            [3]
            [, phantom]
        ]
        [6
            [5]
            [9]
        ]
    ]
    [20
        [12
            [, phantom]
            [14]
        ]
        [29
            [27]
            [, phantom]
        ]
    ]
]
\end{forest}

\vspace{0.3cm}
\textbf{Слика 2.} Пример BST-a.
\end{minipage}
\end{center}

RULES:
- If `known_bst_image = bst_image_1`, insert the predefined LaTeX for known BST image 1
- If `known_bst_image = bst_image_2`, insert the predefined LaTeX for known BST image 2
- Do NOT rewrite the tree structure
- Do NOT generate a new forest layout
- Do NOT use `\includegraphics` for these two known BST images
- Do NOT invent alternate spacing or styling

## CAPTION RULES FOR KNOWN BST IMAGES

If the PDF contains caption text for the known BST image:
- preserve the caption wording as used in the project examples
- do not translate "BST" into Cyrillic
- use project-consistent caption formatting

If an existing valid `.tex` example already shows the correct caption format, copy that format exactly.

## IMAGE HANDLING (GENERIC FALLBACK)

If a task contains some other image in the original PDF that is NOT one of the two known BST images:

### RULES:
- Images MUST be included in LaTeX
- Use \includegraphics
- Use figure environment ONLY if needed, otherwise inline is acceptable
- Use generic image handling ONLY for unknown visuals

### FORMAT:

\begin{center}
\includegraphics[width=0.72\textwidth]{<relative_path_to_image>}
\end{center}

### CAPTION (if exists in PDF):

\textit{<caption>}

## IMAGE PLACEMENT RULES

- Images MUST be placed in the same logical position as in PDF
- Usually:
  - inside "Примери" section
  - or immediately after the relevant example text
- Keep image and its caption together

## IMAGE FILE RULES

- Use relative paths
- Use the real file name and extension
- Do not invent image paths
- Allowed generic fallback file extensions: `.png`, `.jpg`, `.jpeg`

## STRICT IMAGE RULES

- DO NOT skip images
- DO NOT replace non-known images with text descriptions
- DO NOT invent image content
- DO NOT use `\includegraphics` for the two known BST images
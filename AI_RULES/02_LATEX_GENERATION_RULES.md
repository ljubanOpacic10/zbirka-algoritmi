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
- Keep algorithm names (e.g. Merge Sort) as-is

---

## REQUIRED STRUCTURE

\rok{<Mesec Godina.>}{<A/B>}

<test title>

\zadatak{<title>}{%
<description>

\textbf{Додатни захтеви за решавање задатка:}
\begin{itemize}
\item ...
\end{itemize}

\textbf{Потпис методе:}
\begin{Verbatim}[fontsize=\small]
...
\end{Verbatim}

\textbf{Примери:}
...
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
- EXACT copy (no changes)

### Examples
- Format clearly
- Keep Input/Output structure

---

## STRICT RULES

- EXACTLY 3 tasks
- DO NOT invent content
- DO NOT skip sections
- DO NOT change algorithm meaning
- DO NOT mix latin and cyrillic
- DO NOT add explanations outside structure

---

## ERROR HANDLING

If something is unclear:
Add comment in LaTeX:

% TODO: unclear part in original PDF

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

  ## IMAGE HANDLING (CRITICAL)

If a task contains images in the original PDF:

### RULES:
- Images MUST be included in LaTeX
- Use \includegraphics
- Use figure environment ONLY if needed, otherwise inline is acceptable

### FORMAT:

\begin{center}
\includegraphics[width=0.6\textwidth]{<relative_path_to_image>}
\end{center}

### CAPTION (if exists in PDF):

\textit{Slika X - ...}

---

## IMAGE PLACEMENT RULES

- Images MUST be placed in the same logical position as in PDF
- Usually:
  - inside "Примери" section
  - or immediately after description

---

## IMAGE FILE RULES

- Use relative paths
- Image file name MUST be descriptive:

Example:
bst_example_1.png  
bst_example_2.png

---

## STRICT RULES

- DO NOT skip images
- DO NOT replace images with text descriptions
- DO NOT invent image content

## VISUAL RENDERING STRATEGY (CRITICAL)

If a task contains a visual example, choose EXACTLY ONE of the following rendering strategies:

### Strategy A — Reconstruct in native LaTeX
Use native LaTeX reconstruction if:
- the visual is a simple BST/tree/graph-style educational diagram
- the structure can be represented cleanly and faithfully in LaTeX
- reconstruction improves consistency with the collection style

Preferred tools for native reconstruction:
- `forest` for trees
- other already-used project-compatible LaTeX structures if appropriate

### Strategy B — Include extracted image file
Use extracted image files only if:
- the visual is not easy to reconstruct faithfully
- it contains complex styling or layout
- it is not a clean tree/graph candidate for `forest`

RULES:
- NEVER use both strategies for the same visual
- If `image_type = diagram_reconstructable`, prefer native LaTeX reconstruction
- If `image_type = raster_image`, use `\includegraphics`

## TREE / BST DIAGRAM RULES

If the PDF example is a BST or tree diagram and it can be reconstructed:

- Use `forest`
- Preserve node values exactly
- Preserve parent-child relationships exactly
- Preserve missing-child spacing with `phantom` nodes when needed
- Keep captions below the diagram
- Keep the diagram visually centered
- Keep example text ("Улаз", "Излаз") OUTSIDE the forest environment

Preferred layout pattern:

\begin{center}
\begin{minipage}{\textwidth}
\centering
\begin{forest}
...
\end{forest}

\vspace{0.3cm}
\textbf{Слика X.} ...
\end{minipage}
\end{center}

## RASTER IMAGE RULES

If extracted image files must be used:

- Allowed file extensions: `.png`, `.jpg`, `.jpeg`
- Use the real extracted file extension exactly
- The path in `\includegraphics` MUST match the extracted file path exactly
- Do not invent file names
- Use this format:

\begin{center}
\includegraphics[width=0.72\textwidth]{<relative_path>}
\end{center}

\textit{<caption>}
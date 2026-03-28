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

\sablon{AISP<year>_Test<1/2>_Grupa<letter>}{<relative path to linq file>}

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
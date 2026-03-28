# EXTRACTION RULES (PDF → STRUCTURED DATA)

You are extracting structured data from a PDF test for the course "Algoritmi i strukture podataka".

## GOAL
Extract ONLY relevant data for generating LaTeX tasks.

## IGNORE
Completely ignore:
- Instructions for students (time, rules, cheating warnings)
- Header/footer repetitions
- Signature fields

## EXTRACT

### 1. GENERAL INFO
- Test type (Prvi praktični test / Drugi praktični test / Popravni test)
- Date (convert to: "Mesec Godina.")
- Group (A or B)

### 2. TASKS (ALWAYS EXACTLY 3)

For each task extract:

#### - Title
Example:
"Zadatak 1 – Merge Sort" → title = "Merge Sort"

#### - Main description
Full problem statement

#### - Additional requirements
Recognize sections like:
- "Dodatne napomene za rešavanje zadatka"
- "Dodatni zahtevi za rešavanje zadatka"

Extract as bullet points

#### - Method signatures
Extract EXACTLY as written:
Example:
private static void merge(...)

⚠️ DO NOT FIX OR MODIFY SIGNATURES

#### - Examples
Extract all input/output examples

---

## OUTPUT FORMAT (STRICT JSON)

Return ONLY JSON:

{
  "month_year": "",
  "group": "",
  "test_title": "",
  "tasks": [
    {
      "title": "",
      "description": "",
      "requirements": [],
      "signatures": [],
      "examples": []
    }
  ]
}

---

## IMPORTANT RULES

- DO NOT translate content
- DO NOT summarize
- DO NOT add explanations
- DO NOT generate missing parts
- KEEP original meaning EXACT
- If something is unclear → keep it as-is

This step is ONLY extraction.
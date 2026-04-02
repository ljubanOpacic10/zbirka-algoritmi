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

## IMAGE EXTRACTION

If the PDF contains images (e.g. diagrams, trees, graphs, illustrations):

- Detect ALL images related to tasks
- Associate each image with the correct task
- Extract image metadata:

{
  "images": [
    {
      "task_index": 1,
      "caption": "",
      "description": ""
    }
  ]
}

RULES:
- DO NOT ignore images
- DO NOT describe images in text instead of extracting them
- DO NOT generate new images
- If caption exists (e.g. "Slika 1 - Primer BST-a") → extract it
- If no caption → leave empty string

## IMAGE TYPE CLASSIFICATION

If the PDF contains visual examples, classify each visual into one of these types:

- `raster_image` — ordinary extracted image from PDF
- `diagram_reconstructable` — simple structural diagram that can be faithfully rebuilt in LaTeX
  (examples: BST trees, binary trees, simple graph/tree diagrams)
- `unknown_visual`

For each visual store:

{
  "images": [
    {
      "task_index": 1,
      "caption": "",
      "description": "",
      "image_type": "raster_image",
      "image_path": "",
      "reconstruction_hint": ""
    }
  ]
}

RULES:
- If the visual is a simple tree/graph-like academic diagram, prefer `diagram_reconstructable`
- If the visual contains styling, screenshots, or non-trivial graphics, use `raster_image`
- `description` must briefly describe the actual structure shown in the image
- `reconstruction_hint` should contain concise structural information useful for LaTeX reconstruction
  Example:
  "BST root 8; left child 4; right child 9; 4 has children 2 and 5; 2 has right child 3; 9 has right child 11"

## IMAGE CAPTION EXTRACTION

If a caption exists near the image, extract it exactly as it appears in the PDF.

Examples:
- "Slika 1 - Primer BST-a"
- "Slika 2 - Primer BST-a"

Do not rewrite captions during extraction.
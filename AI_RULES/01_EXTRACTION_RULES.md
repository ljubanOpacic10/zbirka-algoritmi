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
Extract EXACTLY as written

Example:
private static void merge(...)

⚠️ DO NOT FIX OR MODIFY SIGNATURES during extraction

#### - Examples
Extract all input/output examples exactly as they appear in the PDF

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
      "examples": [],
      "known_bst_image": "none",
      "images": [],
      "captions": []
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
- Extract image metadata only if needed for downstream processing

Generic fallback structure:

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
- DO NOT describe images in place of extracting them unless the simplified known-image rule applies
- DO NOT generate new images
- If caption exists (e.g. "Slika 1 - Primer BST-a") → extract it
- If no caption → leave empty string

## KNOWN BST IMAGE DETECTION (SIMPLIFIED)

For this project, there are only TWO known BST images that may appear repeatedly in tests.

### Known BST image 1
BST structure:
- root 8
- left child 4
- right child 9
- 4 has children 2 and 5
- 2 has child 3
- 9 has child 11

### Known BST image 2
BST structure:
- root 10
- left child 4
- right child 20
- 4 has children 2 and 6
- 2 has child 3
- 6 has children 5 and 9
- 20 has children 12 and 29
- 12 has child 14
- 29 has child 27

For each task, detect whether:
- no known BST image exists
- known BST image 1 exists
- known BST image 2 exists

Store this in structured output as:

{
  "tasks": [
    {
      "title": "",
      "description": "",
      "requirements": [],
      "signatures": [],
      "examples": [],
      "known_bst_image": "none"
    }
  ]
}

Allowed values:
- "none"
- "bst_image_1"
- "bst_image_2"

RULES:
- Prefer identifying one of the two known BST images instead of generic image extraction
- DO NOT generate image paths for these two known BST images
- DO NOT require external image files for these two known BST images
- If a caption exists in PDF, extract it separately
- If both known BST images appear in the same task, preserve their order of appearance in examples/captions

## IMAGE CAPTION EXTRACTION

If a caption exists near the image, extract it exactly as it appears in the PDF.

Examples:
- "Slika 1 - Primer BST-a"
- "Slika 2 - Primer BST-a"

Do not rewrite captions during extraction.

## GENERIC IMAGE FALLBACK

If a task contains some image that is NOT one of the two known BST images:

- keep generic image metadata in `images`
- preserve caption if available
- leave `known_bst_image` as `"none"`

Use generic image fallback ONLY for unknown visuals.
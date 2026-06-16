---
name: recover-procedures-from-git
description: Recover stored procedure definitions from git history when DB dump file is missing, and convert them to ALTER scripts as individual files.
source: auto-skill
extracted_at: '2026-06-14T01:03:55.703Z'
---

# Recover Stored Procedures From Git & Create ALTER Scripts

When the main DB dump file (`DB cua Hieu/05.06.sql` or similar) has been deleted from the working directory but the project requires ALTER scripts for existing procedures.

## When to use

- User asks for ALTER scripts of procedures that exist in DB but whose definition files are missing
- The main `.sql` dump was deleted or cleaned up from the working directory
- You need to extract procedure definitions that were previously committed to git

## Steps

### 1. Find which procedures are referenced in C# code

Grep the codebase for `sp_` patterns in `SqlCommand` calls:

```
grep -r "SqlCommand.*sp_" --include="*.cs"
```

Also check `CommandType.StoredProcedure` usage to confirm they are called as procedures.

### 2. Check git history for the DB dump file

Find commits that touched the SQL dump:

```bash
git log --all --oneline -- "DB cua Hieu/*.sql"
```

### 3. Extract the dump from git to a temp file

```bash
git show <commit>:"DB cua Hieu/<file>.sql" > "DB cua Hieu\_temp.sql"
```

Use the most recent commit that contains the file.

### 4. Read procedure definitions by line number

First grep for line numbers:

```
grep -n "CREATE PROCEDURE" _temp.sql
```

Then use `read_file` with `offset` and `limit` to read each procedure body.

### 5. Convert CREATE → ALTER and save

For each procedure:
- Change `CREATE PROCEDURE` → `ALTER PROCEDURE`
- Remove `SET ANSI_NULLS ON` / `SET QUOTED_IDENTIFIER ON` (these are session settings, not part of ALTER)
- Keep the body, parameters, and logic identical
- Save to `DB cua Hieu/script/sp_<TenProcedure>.sql`
- End with `GO`

### 6. Clean up temp file

```bash
del "DB cua Hieu\_temp.sql"
```

## Important notes

- **ALTER is safer than DROP+CREATE** for existing procedures — it preserves permissions and dependencies
- Only use `DROP PROCEDURE ...; CREATE PROCEDURE ...` when you are intentionally changing the procedure signature or the user explicitly asks for it
- The `DB cua Hieu/script/` directory is the convention for individual ALTER scripts in this project
- If the DB dump file is still present in the working directory, use it directly instead of git recovery

(
  for %%f in (*.razor *.css) do (
    echo ---------- %%f ----------
    type "%%f"
    echo.
  )
) > merged.txt

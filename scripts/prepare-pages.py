"""Prepare a standalone Blazor publish directory for GitHub project Pages."""
from pathlib import Path
import argparse
import re

parser = argparse.ArgumentParser()
parser.add_argument('directory', type=Path)
parser.add_argument('--base', default='/game-portfolio/')
args = parser.parse_args()
if not re.fullmatch(r'/[A-Za-z0-9_-]+/', args.base):
    parser.error('--base must be a project path such as /game-portfolio/')
index = args.directory / 'index.html'
html = index.read_text(encoding='utf-8-sig')
if '<base href="/" />' not in html:
    raise SystemExit('Expected exactly one unmodified Blazor base path.')
html = html.replace('<base href="/" />', f'<base href="{args.base}" />')
index.write_text(html, encoding='utf-8')
(args.directory / '.nojekyll').touch()
# The site uses hash navigation. Unknown file routes get a useful static 404.
(args.directory / '404.html').write_text(f'''<!doctype html>
<html lang="en"><meta charset="utf-8"><meta name="viewport" content="width=device-width,initial-scale=1">
<title>Off the map — Eren.dev</title><style>body{{background:#10130f;color:#f0f1e9;font:18px system-ui;max-width:650px;margin:20vh auto;padding:28px}}h1{{font-size:48px}}a{{color:#c4f17b}}</style>
<h1>Off the map.</h1><p>This path doesn't lead to a project.</p><a href="{args.base}">Return to Eren's portfolio →</a></html>''', encoding='utf-8')
for required in ['assets/world.svg', 'assets/avatar.svg', 'assets/images/square.png', 'assets/images/woodsman.png', 'assets/images/rocketsan.png', 'css/app.css', 'js/portfolio.js']:
    if not (args.directory / required).is_file():
        raise SystemExit(f'Missing production asset: {required}')
if not list((args.directory / '_framework').glob('*.wasm')):
    raise SystemExit('Published WebAssembly files are missing.')
print(f'Pages prepared and verified: {args.directory} (base {args.base})')

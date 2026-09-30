"""Generate original, deterministic, editable pixel artwork. No external art dependencies."""
from pathlib import Path
import random
random.seed(27)
root = Path(__file__).resolve().parents[1] / 'src/ErenPortfolio/wwwroot/assets'
parts = ['<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 500" shape-rendering="crispEdges"><title>The creative wilds — original pixel landscape</title>']
def rect(x,y,w,h,c,opacity=None):
    parts.append(f'<rect x="{x}" y="{y}" width="{w}" height="{h}" fill="{c}"'+(f' opacity="{opacity}"' if opacity else '')+'/>')
def poly(points,c): parts.append(f'<polygon points="{points}" fill="{c}"/>')
def pine(x,y,s=1,c='#284b38',light='#3c6241'):
    parts.append(f'<g transform="translate({x} {y}) scale({s})">')
    rect(-3,-54,6,56,'#514c32')
    for dy,width in [(-112,8),(-104,16),(-92,26),(-78,36),(-61,46),(-41,56)]:
        rect(-width/2,dy,width,14,c);rect(-width/2,dy,width/2,5,light)
    parts.append('</g>')
# A restrained twilight palette, bands and deliberate square clusters.
rect(0,0,640,500,'#111912')
rect(20,30,600,292,'#152218');rect(48,60,560,240,'#18271e')
for i in range(65):
    x=random.randrange(35,610,4);y=random.randrange(35,245,4)
    rect(x,y,2 if i%4 else 3,2 if i%4 else 3,random.choice(['#6d8960','#44623f','#9cba85']))
# Stepped moon silhouette.
for x,y,w,h in [(445,55,48,72),(433,67,72,48),(427,79,84,24)]: rect(x,y,w,h,'#d6e7a9')
rect(445,67,12,12,'#bed397');rect(469,103,18,12,'#bed397');rect(439,91,6,12,'#c6d99d')
# Cloud banks.
for x,y,w in [(78,83,94),(344,149,150),(514,191,103),(11,210,124),(229,45,82)]:
    rect(x,y,w,5,'#30432d');rect(x+18,y-5,w-34,5,'#30432d');rect(x+28,y+5,w-20,3,'#213522')
# Block-stair mountains.
poly('0,295 0,239 32,239 32,222 60,222 60,198 88,198 88,177 109,177 109,155 132,155 132,181 153,181 153,203 185,203 185,222 224,222 224,245 257,245 257,295','#243b2b')
poly('136,305 136,261 177,261 177,228 201,228 201,191 226,191 226,164 247,164 247,139 268,139 268,111 287,111 287,94 302,94 302,127 321,127 321,161 347,161 347,194 371,194 371,232 406,232 406,305','#304a34')
poly('302,94 302,127 321,127 321,161 347,161 347,194 371,194 371,232 406,232 406,305 276,305 276,207 287,207 287,174 302,174','#1f3628')
poly('256,141 268,141 268,111 287,111 287,94 302,94 302,127 314,127 314,148 296,148 296,136 283,136 283,151 270,151 270,141','#789064')
poly('354,296 354,249 394,249 394,218 420,218 420,193 446,193 446,168 466,168 466,152 480,152 480,172 500,172 500,192 524,192 524,222 555,222 555,248 591,248 591,272 640,272 640,322','#294430')
poly('480,152 480,172 500,172 500,192 524,192 524,222 555,222 555,248 591,248 591,272 640,272 640,322 450,322 450,236 465,236 465,212 480,212','#1c3325')
rect(21,265,178,4,'#435b39');rect(48,273,144,3,'#293e2a');rect(400,267,170,4,'#4b6040');rect(423,275,190,3,'#2e452f')
# Tiny faraway island.
poly('45,264 142,264 142,273 134,273 134,290 117,290 117,309 97,309 97,319 79,319 79,296 60,296 60,279 45,279','#203126')
rect(45,261,97,6,'#637b43');rect(54,267,80,6,'#344829');pine(86,261,.57,'#294532','#3f603b');pine(117,261,.38,'#2d4e36','#597747')
# Main suspended island, grass shelf with jagged stone underbelly.
poly('46,347 599,347 599,367 582,367 582,389 558,389 558,406 539,406 539,428 507,428 507,445 475,445 475,435 447,435 447,466 427,466 427,480 406,480 406,461 382,461 382,449 359,449 359,471 330,471 330,450 297,450 297,431 265,431 265,458 246,458 246,434 215,434 215,421 181,421 181,407 148,407 148,391 110,391 110,377 76,377 76,362 46,362','#263626')
poly('86,359 233,359 233,384 215,384 215,421 181,421 181,407 148,407 148,391 110,391 110,377 86,377','#36402a')
poly('394,356 588,356 588,376 558,376 558,406 539,406 539,428 507,428 507,445 475,445 475,435 447,435 447,466 427,466 427,480 406,480 406,426 394,426','#1c3025')
for i in range(92):
    x=random.randrange(85,560,8);y=random.randrange(365,410,7)
    rect(x,y,random.choice([5,8,12]),random.choice([3,5,7]),random.choice(['#465337','#34472d','#4e5936','#1a2c22']))
rect(46,341,553,10,'#769345');rect(60,334,522,9,'#99b95a');rect(78,328,484,7,'#577b3e')
for i in range(67):
    x=random.randrange(50,595,4);rect(x,random.choice([339,347,351]),random.choice([3,5,9]),random.choice([3,5,7]),random.choice(['#7d9c4b','#c0d878','#4e7238']))
# Far trees stand behind the home and traversable trail.
for x,s in [(204,.8),(248,1.05),(289,.7),(529,1.24),(573,.7),(177,.48)]: pine(x,329,s,'#27492e','#44683a')
# Warm cabin, stepped roof, shaded timbers.
rect(386,256,97,71,'#665d37');rect(395,266,81,61,'#7d7140')
for y in range(273,325,10):rect(393,y,83,3,'#4e5030')
poly('373,259 373,248 385,248 385,237 399,237 399,226 414,226 414,215 435,215 435,225 451,225 451,237 467,237 467,248 487,248 487,259','#303d2a')
poly('373,251 385,251 385,240 399,240 399,229 414,229 414,218 435,218 435,229 451,229 451,240 468,240 468,251 487,251 487,256 373,256','#a09651')
rect(454,219,10,23,'#4e5639');rect(451,215,16,5,'#7e8250')
for x,y in [(455,199),(459,188),(455,178)]:rect(x,y,9,6,'#668267')
rect(444,278,23,40,'#292f22');rect(449,282,14,33,'#e2bd68');rect(460,298,3,3,'#594829');rect(401,274,25,24,'#353d26');rect(404,277,19,18,'#f4d581');rect(411,277,3,18,'#79603a');rect(404,284,19,3,'#79603a');rect(438,319,38,6,'#414b2d');rect(433,325,47,5,'#899353')
# Glowing lamp and a signpost beside the path.
rect(365,297,4,34,'#675f38');rect(359,292,16,6,'#394c2a');rect(362,298,10,11,'#ecd183');rect(164,310,4,21,'#817341');rect(151,303,30,13,'#a49a5b');rect(155,307,16,3,'#445430')
# Waterfall drops from the rock shelf.
rect(306,335,30,18,'#70bcb0');rect(312,353,20,77,'#5b9d8c');rect(316,359,7,93,'#8bcbbb');rect(325,347,4,69,'#b3ddd0');rect(304,336,34,4,'#c2e6c5');rect(309,371,4,21,'#a4d9c5');rect(320,426,4,26,'#587e65');rect(315,464,13,3,'#446e53')
# Ferns, meadow flowers, stones and grass tufts.
for x in [73,110,144,193,230,279,352,381,489,551,587]:
    rect(x,329,3,10,'#9aba65');rect(x-4,332,4,3,'#75934b');rect(x+3,330,4,3,'#adc477')
for x,y in [(126,333),(225,325),(347,330),(499,327),(558,334)]:
    rect(x,y-7,2,8,'#6d9250');rect(x-2,y-10,6,4,'#e7ca7c');rect(x,y-12,2,8,'#ead597')
rect(91,332,13,4,'#a6ad79');rect(96,328,6,4,'#b1bb8a');rect(507,332,16,4,'#919a68');rect(511,327,10,5,'#acb47a')
# Floating debris and depth at the bottom.
rect(160,429,12,8,'#3a4e30');rect(166,437,5,6,'#2e422b');rect(510,466,15,6,'#314831');rect(516,472,5,8,'#233d29');rect(92,399,6,7,'#374e30')
parts.append('</svg>');(root/'world.svg').write_text(''.join(parts),encoding='utf-8')
(root/'avatar.svg').write_text('''<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 30" shape-rendering="crispEdges"><title>Pixel explorer</title><path fill="#15231b" d="M7 1h11v2h3v10h-3v3h3v10h-3v4H4v-4H1V15h4v-3H3V5h4z"/><path fill="#503f2e" d="M7 2h10v2h3v5H5V5h2z"/><path fill="#786044" d="M7 2h8v2H7z"/><path fill="#eac38c" d="M6 8h13v6h-3v3H9v-3H6z"/><path fill="#bf9464" d="M6 12h4v3h6v2H9v-3H6z"/><path fill="#27382a" d="M9 9h2v2H9zm7 0h2v2h-2z"/><path fill="#b0cc6b" d="M6 16h12v9H6z"/><path fill="#6f9245" d="M6 16h4v9H6zm9 0h3v9h-3z"/><path fill="#d5e58b" d="M10 17h4v2h-4z"/><path fill="#7a6643" d="M2 16h4v8H2z"/><path fill="#eac38c" d="M18 18h3v7h-3zM4 23h3v3H4z"/><path fill="#3f5146" d="M7 25h10v3H7z"/><path fill="#b49e6d" d="M5 28h6v2H5zm9 0h5v2h-5z"/></svg>''',encoding='utf-8')
(root/'favicon.svg').write_text('''<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32"><rect width="32" height="32" rx="5" fill="#151c12"/><path d="M12 5h8v7h7v8h-7v7h-8v-7H5v-8h7z" fill="#c4f17b"/><rect x="14" y="14" width="4" height="4" fill="#151c12"/></svg>''',encoding='utf-8')
print('Generated world.svg, avatar.svg, favicon.svg')

# Clearly labeled concept covers for source-only projects without screenshots.
parts = ['<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 400" shape-rendering="crispEdges"><title>Exiled Frontiers systems illustration, not gameplay</title>']
rect(0,0,640,400,'#192620')
for x in range(0,640,24): rect(x,0,1,400,'#22322a')
for y in range(0,400,24): rect(0,y,640,1,'#22322a')
poly('80,196 320,316 560,196 560,218 320,338 80,218','#293d29')
poly('320,316 560,196 560,218 320,338','#203629')
for row in range(6):
    for col in range(6):
        x=320+(col-row)*40; y=76+(col+row)*20
        color=['#566a3e','#607545','#6b8050'][(row+col)%3]
        if row==3 or col==3:color='#899268'
        poly(f'{x},{y} {x+39},{y+20} {x},{y+39} {x-39},{y+20}',color)
        if (row,col) in [(0,0),(0,1),(1,0),(4,0),(5,1),(5,4),(1,5)]: pine(x,y+25,.36,'#264c34','#83a767')
        if (row,col) in [(1,2),(4,4)]:
            rect(x-5,y+5,10,10,'#ccdda5');rect(x-5,y+15,10,11,'#617e98');rect(x-7,y+26,5,4,'#233e36');rect(x+2,y+26,5,4,'#233e36')
# A schematic workshop, warehouse and stone resource.
poly('270,165 307,183 307,143 270,125','#879561');poly('307,183 344,165 344,125 307,143','#526c43');poly('270,125 307,105 344,125 307,145','#b2c67c');rect(314,155,9,18,'#253c2b')
poly('362,215 390,229 419,215 390,201','#bdc299');poly('362,215 390,229 390,243 362,229','#84916b');poly('390,229 419,215 419,229 390,243','#667e59')
rect(255,103,3,35,'#d8cc96');rect(258,103,22,12,'#bbd578')
parts.append('<text x="26" y="33" fill="#cee5ab" font-family="monospace" font-size="12" letter-spacing="3">EXILED FRONTIERS / SYSTEMS STUDY</text>')
parts.append('<text x="141" y="371" fill="#b2c69c" font-family="monospace" font-size="13" letter-spacing="2">GATHER  →  CRAFT  →  BUILD</text></svg>')
(root/'images/exiled-sketch.svg').write_text(''.join(parts),encoding='utf-8')
parts = ['<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 400" shape-rendering="crispEdges"><title>Original concept illustration for a Flappy Bird learning clone, not gameplay</title>']
rect(0,0,640,400,'#162f34')
for x,y,w in [(35,85,145),(340,160,110),(430,80,160)]:
    rect(x,y,w,12,'#29474a');rect(x+25,y-12,w-60,12,'#29474a')
for x in [360,540]:
    rect(x,0,48,116,'#4e754b');rect(x-6,110,60,17,'#769d61');rect(x+7,0,8,110,'#91b674')
    rect(x,270,48,130,'#4e754b');rect(x-6,257,60,17,'#769d61');rect(x+7,278,8,122,'#91b674')
rect(0,363,640,6,'#bed798');rect(0,370,640,30,'#425b45')
# Original tiny blue bird, not a copy of the game's licensed sprite sheet.
rect(201,185,40,30,'#7fc6c9');rect(192,191,49,18,'#7fc6c9');rect(203,177,27,8,'#7fc6c9');rect(229,181,12,13,'#eaf4d8');rect(235,182,6,8,'#25362b');rect(237,199,18,7,'#ebc67e');rect(195,199,20,10,'#467f95');rect(203,214,27,6,'#467f95')
for x,y in [(156,198),(136,213),(117,232)]:rect(x,y,5,5,'#92baba')
parts.append('<text x="26" y="34" fill="#b3d9ce" font-family="monospace" font-size="12" letter-spacing="2">A SMALL STUDY IN GAME FEEL</text></svg>')
(root/'images/flappy-sketch.svg').write_text(''.join(parts),encoding='utf-8')
print('Generated clearly labeled Exiled Frontiers and Flappy Bird concept illustrations')

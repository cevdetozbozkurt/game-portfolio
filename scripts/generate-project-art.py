"""Original SVG concept covers for CV projects without published screenshots.

These diagrams are deliberately illustrative, never presented as project output.
"""
from pathlib import Path
from html import escape

ROOT = Path(__file__).resolve().parents[1] / 'src/ErenPortfolio/wwwroot/assets/images'


def rect(x, y, w, h, color):
    return f'<rect x="{x}" y="{y}" width="{w}" height="{h}" fill="{color}"/>'


def text(x, y, value, size=12, color='#c4d9cf'):
    return f'<text x="{x}" y="{y}" fill="{color}" font-family="monospace" font-size="{size}" letter-spacing="2">{escape(value)}</text>'


def path(points, color, width=6):
    return f'<path d="{points}" fill="none" stroke="{color}" stroke-width="{width}"/>'


def frame(title, color='#8fc7c0'):
    s = '<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 400" shape-rendering="crispEdges">'
    s += f'<title>{escape(title)} - original concept illustration, not project output</title>'
    s += rect(0, 0, 640, 400, '#162321')
    for x in range(0, 640, 24): s += rect(x, 0, 1, 400, '#1d2e29')
    for y in range(0, 400, 24): s += rect(0, y, 640, 1, '#1d2e29')
    s += rect(26, 27, 6, 6, color) + text(46, 34, title.upper(), 11, color)
    for x, y in [(37, 67), (592, 67), (37, 350), (592, 350)]:
        s += rect(x, y, 11, 2, '#4a6250') + rect(x, y, 2, 11, '#4a6250')
    return s


def save(name, s):
    (ROOT / f'{name}-sketch.svg').write_text(s + '</svg>', encoding='utf-8')


def arrow(x, y, color='#8fc7c0'):
    return path(f'M{x} {y}h40m-12 -12 12 12-12 12', color, 4)


def browser(x, y, w, h, color='#b4c896'):
    s = rect(x+6, y+6, w, h, '#0e1815') + rect(x, y, w, h, '#415342')
    s += rect(x+3, y+3, w-6, h-6, '#203029') + rect(x+3, y+3, w-6, 24, '#334b3d')
    for i in range(3): s += rect(x+12+i*12, y+11, 5, 5, color)
    return s


s = frame('Debris / road segmentation')
for x, y, w, h in [(89,97,75,68),(180,97,82,68),(284,97,74,40),(384,97,135,65),(89,194,79,67),(195,207,60,68),(360,207,70,80),(455,201,63,55)]:
    s += rect(x, y, w, h, '#405344') + rect(x+5, y+5, w-10, h-10, '#53634c')
s += path('M68 183H310V312M310 183H548', '#78cdb1', 18)
for x,y in [(190,104),(222,126),(288,240),(480,108),(454,267)]:
    s += rect(x,y,20,18,'#c49c73') + rect(x+5,y+4,22,21,'#b88060')
for x,y,w,h in [(180,95,75,64),(270,226,60,65),(440,91,96,73)]:
    s += f'<rect x="{x}" y="{y}" width="{w}" height="{h}" fill="none" stroke="#dcaa78" stroke-width="2" stroke-dasharray="6 5"/>'
s += text(90,339,'ROAD',11,'#88dfc1') + rect(69,329,10,10,'#88dfc1')
s += text(400,339,'DEBRIS',11,'#dcaa78') + rect(379,329,10,10,'#dcaa78')
save('earthquake',s)

s = frame('Route-level demand forecasting')
s += path('M89 115h120v88h110v-57h130v85h88','#b3cc7c',10)
s += path('M119 242h110v-59h145v-75h136','#78bcb7',10)
for x,y in [(89,115),(209,115),(209,203),(319,203),(449,146),(449,231),(119,242),(229,242),(374,108)]:
    s += rect(x-8,y-8,16,16,'#dfebc5')+rect(x-3,y-3,6,6,'#20342b')
s += rect(74,290,484,51,'#24392e')
s += path('M88 326h54v-9h47v6h51v-17h49v-8h49v13h47v-6h51v15h48v-6h52','#a8d5c7',3)
save('transit',s)

s = frame('Documents / retrieval / answers')
for i in range(3):
    x=94+i*13; y=124-i*14
    s+=rect(x,y,90,132,'#425b49')+rect(x+4,y+4,82,124,'#c3d5ac')
    for j in range(4):s+=rect(x+15,y+35+j*17,52-(j%2)*12,4,'#5b7960')
s+=text(133,122,'DOC',12,'#294835')+arrow(230,189)
s+=rect(286,134,104,110,'#567767')+rect(299,147,78,84,'#293e33')
for x,y in [(312,166),(345,166),(312,202),(345,202)]:s+=rect(x,y,13,13,'#a8d7b5')
s+=arrow(408,189)+rect(466,130,94,104,'#87bca7')+rect(476,234,15,16,'#87bca7')
for j in range(3):s+=rect(480,153+j*20,61-j*9,5,'#284a3b')
s+=text(112,296,'COLLECT',11)+text(295,296,'RETRIEVE',11)+text(475,296,'ANSWER',11)
save('rag',s)

s=frame('Cloud computing / practical study','#ddbd86')
for i,label in enumerate(['WEB','APP','DATA']):
    x=96+i*166
    s+=rect(x,136,116,139,'#584f39')+rect(x+5,141,106,129,'#25392e')
    for j in range(3):
        s+=rect(x+13,154+j*34,90,24,'#596c49')+rect(x+21,161+j*34,8,8,'#cadd96')
        s+=rect(x+40,164+j*34,49,3,'#a2ac80')
    s+=text(x+35,300,label,11,'#ddbd86')
s+=path('M154 121V89H486V121M320 89v32','#d0b481',4)
save('cloud',s)

s=frame('MVC / shop systems study','#ddbd86')+browser(113,80,414,238,'#ddbd86')
for i in range(3):
    x=136+i*126
    s+=rect(x,133,103,113,'#354b3c')+rect(x+19,151,66,54,'#668260')
    s+=rect(x+29,141,46,12,'#b9c98f')+rect(x+45,168,14,14,'#d6dbab')
    s+=rect(x+13,217,70,5,'#b6c796')+rect(x+13,230,38,4,'#768868')
s+=rect(402,268,100,24,'#c1c888')+text(418,285,'CART',10,'#2c4030')
save('ecommerce',s)

s=frame('Browser workflow / automation study','#b9add2')+browser(86,96,259,218,'#b9add2')
for j in range(3):
    s+=rect(109,146+j*45,205,29,'#3b4d43')+rect(123,155+j*45,11,11,'#8aa88a')
    s+=rect(146,159+j*45,127,4,'#a7ba9b')
s+=arrow(368,197,'#b9add2')
for j in range(3):
    s+=rect(447,113+j*71,84,47,'#4e5960')+text(468,143+j*71,'0'+str(j+1),14,'#e2cfeb')
    if j<2:s+=path(f'M489 {160+j*71}v24','#8b91a0',4)
save('automation',s)

s=frame('Speed measurement / threshold study','#b9add2')
for i in range(13):
    x=134+i*28; h=32+min(i,12-i)*19
    s+=rect(x,257-h,17,h,'#68897b' if i<9 else '#b8a5ba')
s+=path('M320 256l81-104','#dece9b',8)+rect(309,246,22,22,'#e8dfc0')
s+=rect(127,284,388,3,'#485d4b')+text(228,318,'MEASURE > COMPARE',11,'#c9c6d9')
save('speed',s)

s=frame('Python / small steps, steady progress')+browser(104,85,432,235)
s+=text(128,146,'>>> learn()',18,'#c0dc9e')
for j,w in enumerate([216,285,189,251]):
    s+=text(131,183+j*26,'>',14,'#72ad95')+rect(155,173+j*26,w,7,'#749282' if j%2==0 else '#445e4c')
s+=rect(162,284,11,17,'#c0dc9e')
save('python',s)

s=frame('Play / recognise / colour','#d4c493')
s+=rect(176,81,288,222,'#b4bd94')+rect(184,89,272,206,'#d4dbc1')
# Original pixel animal silhouette, a concept rather than a recreated game asset.
for x,y,w,h in [(238,125,35,61),(367,125,35,61),(258,156,129,104),(275,252,96,19)]:s+=rect(x,y,w,h,'#718e79')
s+=rect(257,139,14,32,'#b7c9a8')+rect(369,139,14,32,'#b7c9a8')
s+=rect(282,191,13,14,'#213e32')+rect(349,191,13,14,'#213e32')
s+=rect(314,215,14,10,'#d3b288')+rect(310,229,23,4,'#294b39')
for i,color in enumerate(['#c98f78','#dfc879','#85ad83','#77adb0','#b69bb5']):
    s+=rect(208+i*46,324,31,23,color)
save('animal-colouring',s)
print('Generated nine original, explicitly labelled project concept covers.')

#!/bin/sh

colors='ffffff bfbfbf 808080 404040 000000 6699ff 3366cc 003399 99cc33 00cc00 669900 ffcc00 ff9900 ff6600 cc0000'

generate_svg()
{
  infile=$1
  outfile="../Assets/Art/$2"
  if [ ! -e $outfile ]
  then
    gimp -idf --batch-interpreter=python-fu-eval -b - 2> /dev/null << EOF
import gimpfu

def svgtopng(infile,outfile):
  img = pdb.file_svg_load(infile, '', 300, 0, 0, 0)
  layer = pdb.gimp_image_merge_visible_layers(img, CLIP_TO_IMAGE)
  pdb.plug_in_autocrop(img, layer)
  pdb.gimp_file_save(img, layer, outfile, '?')
  pdb.gimp_image_delete(img)

svgtopng('${infile}','${outfile}')

pdb.gimp_quit(1)
EOF
  fi
}

simple_sprite() {
  name=$1
  generate_svg "$name.svg" "$name.png"
}

single_person() {
  name=$1
  n=96 # magic

  for color in $colors
  do
    n=$((n+1))
    filename=$(/usr/bin/printf "$name-\x$(printf %x $n).png")
    sed -i "0,/fill:#[0-9a-f]\+;/{s/fill:#[0-9a-f]\+;/fill:#$color;/}" "$name.svg"
    generate_svg "$name.svg" $filename
  done
}

two_persons() {
  name=$1
  j=96 # magic

  for color_a in $colors
  do
    j=$((j+1))
    k=96 # magic
    sed -i "0,/fill:#[0-9a-f]\+;/{s/fill:#[0-9a-f]\+;/fill:#$color_a;/}" "$name.svg"
    for color_b in $colors
    do
      k=$((k+1))
      filename=$(/usr/bin/printf "$name-\x$(printf %x $j)-\x$(printf %x $k).png")
      sed -i "72,/fill:#[0-9a-f]\+;/{s/fill:#[0-9a-f]\+;/fill:#$color_b;/}" "$name.svg"
      generate_svg "$name.svg" $filename
    done
  done
}

simple_sprite "faucet"
simple_sprite "alien"
simple_sprite "doctor"
simple_sprite "cough"
simple_sprite "door"
simple_sprite "opendoor"
simple_sprite "key"
simple_sprite "table"
simple_sprite "dish0"
simple_sprite "dish1"
simple_sprite "dish2"
simple_sprite "dish3"
simple_sprite "dish4"
simple_sprite "dish5"
simple_sprite "fork"
simple_sprite "knife"
single_person "npc"
single_person "dead"
single_person "mask"
single_person "gasmask"
two_persons "grabbingdead"

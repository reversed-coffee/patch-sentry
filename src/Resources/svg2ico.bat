@echo off
inkscape -w 16 -h 16 -o 16.png %1.svg
inkscape -w 32 -h 32 -o 32.png %1.svg
inkscape -w 48 -h 48 -o 48.png %1.svg
magick convert 16.png 32.png 48.png %1.ico
del 16.png 32.png 48.png
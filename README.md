# SolarWall
SolarWall is a 650 Wh Li-ion IoT battery pack powered by a 150W solar panel. This project is currently in the prototyping stage.

<p align="center"> 
  <img src="https://i.imgur.com/TzPAlm2.jpg?1" width="600">
</p>

## Overview

A high level overview of the planned final design is shown below.

<p align="center"> 
  <img src="https://i.imgur.com/wTpWAlf.png" width="800">
</p>

A single 150W 30V solar panel is connected to an adjustable buck converter, which provides the required 21V for the BMS. A high power mosfet acts as a master switch, and current is monitored by a 50A 75mV shunt. 

A 5S 60A rated BMS balances each cell group during charging and discharging, as well as protecting against overcurrent, overvoltage, and undervoltage. Each cell group consists of an arbitrary number of similar capacity 18650 Li-Ion cells. 

A 5V buck converter provides up to 3A output to an array of USB and Lightning ports, as well as power for the Arduino and ESP8266 microcontrollers.

Panel voltage, charge current, and cell group voltages are displayed through a web app, which also controls the panel master cutoff and pack master cutoff.

## Prototype

An overview of the most recent prototype (shown above) is shown below. A 24V DC converter with max 2.5A draw is used to simulate a solar panel, to enable testing during overcast weather/night.

<p align="center"> 
  <img src="https://i.imgur.com/c262yM2.png" width="600">
</p>

The controller PCB (being fabricated at time of writing) schematic and visualization is shown below.

<p align="center"> 
  <img src="https://i.imgur.com/mV8I3EL.png" width="800
</p>

<p align="center"> 
  <img src="https://i.imgur.com/kpKGa7W.png?1" width="300">
</p>

A cell charger/discharger was also built using a TP4056 Li-ion charger/discharger and 4 ohm power resistor. 

<p align="center"> 
  <img src="https://i.imgur.com/CKhYoin.jpg?1" width="400">
</p>

## Development Photos

Salvaging 18650 cells from old laptop batteries.

<p align="center"> 
  <img src="https://i.imgur.com/sjUPqaz.jpg" width="200">
</p>

Testing solar panel output voltage and current.

<p align="center"> 
  <img src="https://i.imgur.com/ilDZ7Tw.jpg" width="300">
</p>

Constructing Prototype

<p align="center"> 
  <img src="https://i.imgur.com/SMs5KAW.jpg" width="400">
</p>

<p align="center"> 
  <img src="https://i.imgur.com/bCNrP9H.jpg" width="400">
</p>


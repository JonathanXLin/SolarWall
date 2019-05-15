# SolarWall
SolarWall is a 650 Wh Li-ion IoT battery pack powered by a 150W solar panel. This project is currently in the prototyping stage.

<p align="center"> 
  <img src="https://i.imgur.com/wTpWAlf.png" width="1200">
</p>

## Overview

A high level overview of the planned final design is shown below.

<p align="center"> 
  <img src="https://i.imgur.com/wTpWAlf.png" width="1200">
</p>

A single 150W 30V solar panel is connected to an adjustable buck converter, which provides the required 21V for the BMS. A high power mosfet acts as a master switch, and current is monitored by a 50A 75mV shunt. 

A 5S 60A rated BMS balances each cell group during charging and discharging, as well as protecting against overcurrent, overvoltage, and undervoltage. Each cell group consists of an arbitrary number of similar capacity 18650 Li-Ion cells. 

A 5V buck converter provides up to 3A output to an array of USB and Lightning ports, as well as power for the Arduino and ESP8266 microcontrollers.

Panel voltage, charge current, and cell group voltages are displayed through a web app, which also controls the panel master cutoff and pack master cutoff.

## Prototype

An overview of the most recent prototype (shown above) is shown below. 

<p align="center"> 
  <img src="https://i.imgur.com/c262yM2.png" width="1200">
</p>

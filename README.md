# SolarWall
SolarWall is a 650 Wh Li-ion IoT battery pack powered by a 150W solar panel. This project is currently in the prototyping stage.

## Overview

A high level overview of the planned final design is shown below.

<p align="center"> 
  <img src="https://i.imgur.com/wTpWAlf.png" width="1200">
</p>

A single 150W 30V solar panel is connected to an adjustable buck converter, which provides the required 21V for the BMS. A high power mosfet acts as a master switch, and current is monitored by a 50A 75mV shunt. 

A 5S 60A rated BMS balances each cell group during charging and discharging, as well as protecting against overcurrent, overvoltage, and undervoltage. Each cell group consists of an arbitrary number of similar capacity 18650 Li-Ion cells. 


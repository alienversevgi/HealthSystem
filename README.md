# Unity Health System

A modular, extensible health management system for Unity, designed with flexibility and SOLID principles. Supports various damage types, resistances, healing, buffs/debuffs, status effect and strategy-driven behavior.

## Features

✅ **Damage Types**
- Easily define and extend various damage types (e.g., Physical, Fire, Poison).

✅ **Resistances**
- Entities can define resistances against specific damage types.
- Automatically applies resistance values when taking damage.

✅ **Health Controller**
- Centralized component to manage health, healing, damage, and death.
- Supports any entities.

✅ **Strategy Pattern**
- Plug-and-play architecture using strategy interfaces for health-related actions:
  - Damage processing
  - Healing strategies
  - Death behavior
- Makes extending and customizing behavior easy and decoupled.

✅ **Health Effects**
- Apply effects such as:
  - Damage over time (DoT)
  - Healing over time (HoT)
  - Temporary invincibility
  - Buffs and debuffs
- Can be timed or condition-based.

✅ **Event-Driven Architecture**
- Notifies other systems on:
  - Health changes
  - Death
  - Damage received
- Useful for triggering VFX, SFX, or animations.

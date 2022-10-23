﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;



class LizardPeasant : MainClothing
{
    public LizardPeasant()
    {
        clothing1 = new SpriteExtraInfo(10, null, null);
        clothing2 = new SpriteExtraInfo(17, null, WhiteColored);
        blocksBreasts = true;
        bellyColor = new Color32(240, 183, 87, 1);
        colorsBelly = true;
        DiscardSprite = null;
        Type = 78;
        OccupiesAllSlots = true;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        clothing1.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.ClothingStrict, actor.Unit.ClothingColor);
        clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardPeasant[actor.IsAttacking ? 1 : 0];
        clothing1.layer = 13;
        clothing2.GetSprite = (s) => actor.Unit.HasBreasts ? State.GameManager.SpriteDictionary.LizardPeasant[actor.Unit.BreastSize > 6 ? 6 : (2 + actor.Unit.BreastSize / 2)] : null;
        clothing2.layer = 14;
        base.Configure(sprite, actor);
    }
}

class LizardLeaderCrown : ClothingAccessory
{
    public LizardLeaderCrown()
    {
        leaderOnly = true;
        clothing1 = new SpriteExtraInfo(10, null, WhiteColored);
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardLeader[2];
        base.Configure(sprite, actor);
    }
}

class LizardLeaderTop : MainClothing
{
    public LizardLeaderTop()
    {
        Type = 117;
        coversBreasts = false;
        blocksDick = false;
        leaderOnly = true;
        FixedColor = true;
        DiscardSprite = State.GameManager.SpriteDictionary.LizardLeader[5];
        clothing1 = new SpriteExtraInfo(16, null, WhiteColored);
        OccupiesAllSlots = false;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        blocksDick = false;
        bool attacking = actor.IsAttacking;
        sprite.ChangeLayer(SpriteType.Breasts, 15);
        sprite.ChangeLayer(SpriteType.Belly, 14);
        clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardLeader[0 + (attacking ? 1 : 0)];
        base.Configure(sprite, actor);
    }
}

class LizardLeaderSkirt : MainClothing
{
    public LizardLeaderSkirt()
    {
        Type = 6010;
        coversBreasts = false;
        blocksDick = false;
        leaderOnly = true;
        FixedColor = true;
        DiscardSprite = null;
        clothing2 = new SpriteExtraInfo(12, null, null);
        OccupiesAllSlots = false;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        blocksDick = false;
        clothing2.layer = 12;
        clothing2.GetSprite = (s) =>
            {
                if (actor.IsErect())
                    return null;
                return State.GameManager.SpriteDictionary.LizardLeader[3];
            };
        base.Configure(sprite, actor);
    }
}

class LizardLeaderLegguards : MainClothing
{
    public LizardLeaderLegguards()
    {
        Type = 6002;
        coversBreasts = false;
        blocksDick = false;
        leaderOnly = true;
        FixedColor = true;
        DiscardSprite = null;
        clothing1 = new SpriteExtraInfo(11, null, null);
        OccupiesAllSlots = true;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        blocksDick = false;
        int bellySize = actor.GetStomachSize();
        clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardLeader[4];
        {
            if (actor.IsErect())
            {
                if (bellySize > 3)
                {
                    sprite.ChangeLayer(SpriteType.Belly, 14);
                    sprite.ChangeLayer(SpriteType.Dick, 13);
                    sprite.ChangeLayer(SpriteType.Balls, 12);
                }
                else if (bellySize < 3)
                {
                    sprite.ChangeLayer(SpriteType.Dick, 21);
                    sprite.ChangeLayer(SpriteType.Balls, 20);
                }
            }
        };
        base.Configure(sprite, actor);
    }
}

class LizardLeaderArmbands : MainClothing
{
    public LizardLeaderArmbands()
    {
        Type = 6002;
        coversBreasts = false;
        leaderOnly = true;
        FixedColor = true;
        DiscardSprite = null;
        clothing1 = new SpriteExtraInfo(3, null, WhiteColored);
        OccupiesAllSlots = false;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        bool attacking = actor.IsAttacking;
        blocksDick = false;
        clothing1.layer = 3;
        clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardLeader[6 + (attacking ? 1 : 0)];
        base.Configure(sprite, actor);
    }
}

class LizardBoneCrown : ClothingAccessory
{
    public LizardBoneCrown()
    {
        leaderOnly = false;
        clothing1 = new SpriteExtraInfo(10, null, WhiteColored);
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardBone[14];
        base.Configure(sprite, actor);
    }
}

class LizardBoneTop : MainClothing
{
    public LizardBoneTop()
    {
        Type = 6000;
        blocksDick = false;
        leaderOnly = false;
        FixedColor = true;
        DiscardSprite = State.GameManager.SpriteDictionary.LizardBone[15];
        clothing1 = new SpriteExtraInfo(10, null, null);
        clothing2 = new SpriteExtraInfo(11, null, null);
        OccupiesAllSlots = false;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        clothing1.GetSprite = (s) =>
            {
                if (actor.Unit.HasBreasts)
                {
                    if (actor.Unit.BreastSize >= 7)
                    {
                        coversBreasts = false;
                        return State.GameManager.SpriteDictionary.LizardBone[15];
                    }
                    coversBreasts = false;
                    return State.GameManager.SpriteDictionary.LizardBone[8];
                }
                else
                    coversBreasts = true;
                return State.GameManager.SpriteDictionary.LizardBone[0];
            };

        clothing2.GetSprite = (s) =>
            {
                coversBreasts = true;
                if (actor.Unit.BreastSize >= 0)
                {
                    if (actor.Unit.BreastSize >= 6)
                    {
                        coversBreasts = false;
                        clothing2.layer = 17;
                        sprite.ChangeLayer(SpriteType.Breasts, 16);
                        if (actor.Unit.BreastSize >= 7)
                        {
                            coversBreasts = false;
                            sprite.ChangeLayer(SpriteType.Breasts, 16);
                            return State.GameManager.SpriteDictionary.LizardBone[15];
                        }
                        else return State.GameManager.SpriteDictionary.LizardBone[1 + actor.Unit.BreastSize];
                    }


                    else
                    {
                        clothing2.layer = 11;
                        return State.GameManager.SpriteDictionary.LizardBone[1 + actor.Unit.BreastSize];
                    }

                }

                return null;
            };
        base.Configure(sprite, actor);
    }
}

class LizardBoneLoins : MainClothing
{
    public LizardBoneLoins()
    {
        Type = 6001;
        coversBreasts = false;
        blocksDick = false;
        leaderOnly = false;
        FixedColor = true;
        DiscardSprite = State.GameManager.SpriteDictionary.LizardBone[10];
        clothing2 = new SpriteExtraInfo(12, null, WhiteColored);
        OccupiesAllSlots = false;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        blocksDick = false;
        clothing2.layer = 12;
        clothing2.GetSprite = (s) =>
            {
                if (actor.IsErect())
                    return null;
                return State.GameManager.SpriteDictionary.LizardBone[10];
            };
        base.Configure(sprite, actor);
    }
}

class LizardBoneLegguards : MainClothing
{
    public LizardBoneLegguards()
    {
        Type = 6002;
        coversBreasts = false;
        blocksDick = false;
        leaderOnly = false;
        FixedColor = true;
        DiscardSprite = null;
        clothing1 = new SpriteExtraInfo(11, null, null);
        OccupiesAllSlots = true;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        blocksDick = false;
        int bellySize = actor.GetStomachSize();
        clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardBone[9];
        {
            if (actor.IsErect())
            {
                if (bellySize > 3)
                {
                    sprite.ChangeLayer(SpriteType.Belly, 14);
                    sprite.ChangeLayer(SpriteType.Dick, 13);
                    sprite.ChangeLayer(SpriteType.Balls, 12);
                }
                else if (bellySize < 3)
                {
                    sprite.ChangeLayer(SpriteType.Dick, 21);
                    sprite.ChangeLayer(SpriteType.Balls, 20);
                }
            }
        };
        base.Configure(sprite, actor);
    }
}

class LizardBoneArmbands1 : MainClothing
{
    public LizardBoneArmbands1()
    {
        Type = 6002;
        coversBreasts = false;
        leaderOnly = false;
        FixedColor = true;
        DiscardSprite = null;
        clothing1 = new SpriteExtraInfo(10, null, WhiteColored);
        OccupiesAllSlots = false;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        bool attacking = actor.IsAttacking;
        blocksDick = false;
        clothing1.layer = 2;
        clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardBone[12 + (attacking ? 1 : 0)];
        base.Configure(sprite, actor);
    }
}

class LizardBoneArmbands2 : MainClothing
{
    public LizardBoneArmbands2()
    {
        Type = 6002;
        coversBreasts = false;
        leaderOnly = false;
        FixedColor = true;
        DiscardSprite = null;
        clothing1 = new SpriteExtraInfo(10, null, WhiteColored);
        OccupiesAllSlots = false;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        bool attacking = actor.IsAttacking;
        blocksDick = false;
        clothing1.layer = 2;
        clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardBone[11];
        base.Configure(sprite, actor);
    }
}

class LizardBoneArmbands3 : MainClothing
{
    public LizardBoneArmbands3()
    {
        Type = 6002;
        coversBreasts = false;
        leaderOnly = false;
        FixedColor = true;
        DiscardSprite = null;
        clothing1 = new SpriteExtraInfo(10, null, WhiteColored);
        clothing2 = new SpriteExtraInfo(10, null, WhiteColored);
        OccupiesAllSlots = false;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        bool attacking = actor.IsAttacking;
        blocksDick = false;
        clothing1.layer = 2;
        clothing2.layer = 3;
        clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardBone[11];
        clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardBone[12 + (attacking ? 1 : 0)];
        base.Configure(sprite, actor);
    }
}

class LizardLeatherCrown : ClothingAccessory
{
    public LizardLeatherCrown()
    {
        leaderOnly = false;
        clothing1 = new SpriteExtraInfo(10, null, null);
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardLeather[23];
        base.Configure(sprite, actor);
    }
}

class LizardLeatherTop : MainClothing
{
    public LizardLeatherTop()
    {
        Type = 6000;
        coversBreasts = false;
        blocksDick = false;
        leaderOnly = false;
        FixedColor = false;
        DiscardSprite = State.GameManager.SpriteDictionary.LizardLeather[14];
        clothing1 = new SpriteExtraInfo(16, null, null);
        clothing2 = new SpriteExtraInfo(17, null, null);
        OccupiesAllSlots = false;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        sprite.ChangeLayer(SpriteType.Breasts, 15);
        sprite.ChangeLayer(SpriteType.Belly, 14);
        int bellySize = actor.GetStomachSize();
        if (bellySize < 1)
        {
            clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardLeather[0];
        }
        else if (bellySize <= 1)
            clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardLeather[1];
        else if (bellySize > 1)
            clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardLeather[2];
        else if (bellySize > 2)
            clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardLeather[3];
        else if (bellySize > 3)
            clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardLeather[4];
        else if (bellySize > 4)
            clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardLeather[5];
        else if (bellySize > 5)
            clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardLeather[6];
        else if (bellySize > 6)
            clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardLeather[7];

        clothing2.GetSprite = (s) =>
        {
            coversBreasts = false;
            if (actor.Unit.BreastSize <= 1)
                sprite.HideSprite(SpriteType.Clothing2);
            else if (actor.Unit.BreastSize >= 8)
            {
                coversBreasts = false;
                sprite.ChangeLayer(SpriteType.Breasts, 16);
                return State.GameManager.SpriteDictionary.LizardLeather[15];
            }
            return State.GameManager.SpriteDictionary.LizardLeather[8 + actor.Unit.BreastSize];
        };
        base.Configure(sprite, actor);
    }
}

class LizardLeatherLoins : MainClothing
{
    public LizardLeatherLoins()
    {
        Type = 6001;
        coversBreasts = false;
        blocksDick = false;
        leaderOnly = false;
        FixedColor = false;
        DiscardSprite = State.GameManager.SpriteDictionary.LizardLeather[17];
        clothing1 = new SpriteExtraInfo(12, null, null);
        OccupiesAllSlots = false;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        blocksDick = false;
        clothing1.GetSprite = (s) =>
            {
                if (actor.IsErect())
                    return null;
                return State.GameManager.SpriteDictionary.LizardLeather[17];
            };
        base.Configure(sprite, actor);
    }
}

class LizardLeatherLegguards : MainClothing
{
    public LizardLeatherLegguards()
    {
        Type = 6002;
        coversBreasts = false;
        blocksDick = false;
        leaderOnly = false;
        FixedColor = false;
        DiscardSprite = null;
        clothing1 = new SpriteExtraInfo(11, null, null);
        OccupiesAllSlots = false;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        blocksDick = false;
        int bellySize = actor.GetStomachSize();
        clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardLeather[16];
        {
            if (actor.IsErect())
            {
                if (bellySize > 3)
                {
                    sprite.ChangeLayer(SpriteType.Belly, 15);
                    sprite.ChangeLayer(SpriteType.Dick, 14);
                    sprite.ChangeLayer(SpriteType.Balls, 13);
                }
                else if (bellySize < 3)
                {
                    sprite.ChangeLayer(SpriteType.Dick, 21);
                    sprite.ChangeLayer(SpriteType.Balls, 20);
                }
            }

        };
        base.Configure(sprite, actor);
    }
}

class LizardLeatherArmbands1 : MainClothing
{
    public LizardLeatherArmbands1()
    {
        Type = 6002;
        coversBreasts = false;
        leaderOnly = false;
        FixedColor = true;
        DiscardSprite = null;
        clothing1 = new SpriteExtraInfo(10, null, WhiteColored);
        OccupiesAllSlots = false;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        bool attacking = actor.IsAttacking;
        blocksDick = false;
        clothing1.layer = 2;
        clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardLeather[18 + (attacking ? 1 : 0)];
        base.Configure(sprite, actor);
    }
}

class LizardLeatherArmbands2 : MainClothing
{
    public LizardLeatherArmbands2()
    {
        Type = 6002;
        coversBreasts = false;
        leaderOnly = false;
        FixedColor = true;
        DiscardSprite = null;
        clothing1 = new SpriteExtraInfo(10, null, WhiteColored);
        OccupiesAllSlots = false;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        bool attacking = actor.IsAttacking;
        blocksDick = false;
        clothing1.layer = 2;
        clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardLeather[20 + (attacking ? 1 : 0)];
        base.Configure(sprite, actor);
    }
}

class LizardLeatherArmbands3 : MainClothing
{
    public LizardLeatherArmbands3()
    {
        Type = 6002;
        coversBreasts = false;
        leaderOnly = false;
        FixedColor = true;
        DiscardSprite = null;
        clothing1 = new SpriteExtraInfo(10, null, WhiteColored);
        OccupiesAllSlots = false;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        blocksDick = false;
        clothing1.layer = 2;
        clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardLeather[22];
        base.Configure(sprite, actor);
    }
}

class LizardClothCrown : ClothingAccessory
{
    public LizardClothCrown()
    {
        leaderOnly = false;

        clothing1 = new SpriteExtraInfo(10, null, WhiteColored);
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardCloth[15];
        base.Configure(sprite, actor);
    }
}

class LizardClothTop : MainClothing
{
    public LizardClothTop()
    {
        Type = 6000;
        blocksDick = false;
        leaderOnly = false;
        FixedColor = true;
        DiscardSprite = State.GameManager.SpriteDictionary.LizardCloth[14];
        clothing1 = new SpriteExtraInfo(16, null, null);
        OccupiesAllSlots = false;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        sprite.ChangeLayer(SpriteType.Belly, 14);
        sprite.ChangeLayer(SpriteType.Breasts, 15);
        clothing1.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.ClothingStrictRedKey, actor.Unit.ClothingColor);
        clothing1.GetSprite = (s) =>
            {
                coversBreasts = false;
                if (actor.Unit.BreastSize <= 1)
                    return State.GameManager.SpriteDictionary.LizardCloth[1];
                else if (actor.Unit.BreastSize >= 8)
                {
                    return State.GameManager.SpriteDictionary.LizardCloth[7];
                }
                return State.GameManager.SpriteDictionary.LizardCloth[0 + actor.Unit.BreastSize];
            };
        base.Configure(sprite, actor);
    }
}

class LizardClothLoins : MainClothing
{
    public LizardClothLoins()
    {
        Type = 6001;
        coversBreasts = false;
        blocksDick = false;
        leaderOnly = false;
        FixedColor = true;
        DiscardSprite = State.GameManager.SpriteDictionary.LizardCloth[11];
        clothing2 = new SpriteExtraInfo(12, null, WhiteColored);
        OccupiesAllSlots = false;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        blocksDick = false;
        clothing2.layer = 13;
        clothing2.GetSprite = (s) =>
            {
                if (actor.IsErect())
                    return null;
                return State.GameManager.SpriteDictionary.LizardCloth[11];
            };
        base.Configure(sprite, actor);
    }
}

class LizardClothShorts : MainClothing
{
    public LizardClothShorts()
    {
        Type = 6002;
        coversBreasts = false;
        blocksDick = false;
        leaderOnly = false;
        FixedColor = true;
        DiscardSprite = null;
        clothing1 = new SpriteExtraInfo(11, null, null);
        OccupiesAllSlots = true;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        int bellySize = actor.GetStomachSize();
        clothing1.GetSprite = (s) =>
            {
                if (actor.IsErect())
                {
                    if (bellySize > 3)
                    {
                        sprite.ChangeLayer(SpriteType.Belly, 14);
                        sprite.ChangeLayer(SpriteType.Dick, 13);
                        sprite.ChangeLayer(SpriteType.Balls, 12);
                    }
                    else if (bellySize < 3)
                    {
                        sprite.ChangeLayer(SpriteType.Dick, 21);
                        sprite.ChangeLayer(SpriteType.Balls, 20);
                    }
                    return State.GameManager.SpriteDictionary.LizardCloth[8];
                }
                else
                {
                    sprite.HideSprite(SpriteType.Dick);
                    sprite.HideSprite(SpriteType.Balls);
                    return State.GameManager.SpriteDictionary.LizardCloth[9];
                }
            };
        base.Configure(sprite, actor);
    }
}

class LizardClothArmbands1 : MainClothing
{
    public LizardClothArmbands1()
    {
        Type = 6002;
        coversBreasts = false;
        leaderOnly = false;
        FixedColor = true;
        DiscardSprite = null;
        clothing1 = new SpriteExtraInfo(10, null, WhiteColored);
        OccupiesAllSlots = false;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        bool attacking = actor.IsAttacking;
        blocksDick = false;
        clothing1.layer = 2;
        clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardCloth[13 + (attacking ? 1 : 0)];
        base.Configure(sprite, actor);
    }
}

class LizardClothArmbands2 : MainClothing
{
    public LizardClothArmbands2()
    {
        Type = 6002;
        coversBreasts = false;
        leaderOnly = false;
        FixedColor = true;
        DiscardSprite = null;
        clothing1 = new SpriteExtraInfo(10, null, WhiteColored);
        OccupiesAllSlots = false;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        bool attacking = actor.IsAttacking;
        blocksDick = false;
        clothing1.layer = 2;
        clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardCloth[12];
        base.Configure(sprite, actor);
    }
}

class LizardClothArmbands3 : MainClothing
{
    public LizardClothArmbands3()
    {
        Type = 6002;
        coversBreasts = false;
        leaderOnly = false;
        FixedColor = true;
        DiscardSprite = null;
        clothing1 = new SpriteExtraInfo(10, null, WhiteColored);
        clothing2 = new SpriteExtraInfo(10, null, WhiteColored);
        OccupiesAllSlots = false;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        bool attacking = actor.IsAttacking;
        blocksDick = false;
        clothing1.layer = 2;
        clothing2.layer = 3;
        clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardCloth[12];
        clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardCloth[13 + (attacking ? 1 : 0)];
        base.Configure(sprite, actor);
    }
}

class RainCoat : MainClothing
{
    public RainCoat()
    {
        blocksDick = false;
        blocksBreasts = true;
        clothing1 = new SpriteExtraInfo(19, null, null);
        clothing2 = new SpriteExtraInfo(20, null, null);
        clothing3 = new SpriteExtraInfo(21, null, null);
        clothing4 = new SpriteExtraInfo(0, null, null);
        Type = 79;
        DiscardSprite = State.GameManager.SpriteDictionary.RainCoats[4];
        FixedColor = true;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        bool heavyWeight = actor.GetBodyWeight() == 1;
        clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.RainCoats[0 + (actor.IsAttacking ? 1 : 0) + (heavyWeight ? 2 : 0)];

        int bellySize = actor.GetStomachSize();
        sprite.ChangeSprite(SpriteType.Hair, State.GameManager.SpriteDictionary.RainCoats[19 + (actor.Unit.HairStyle % 4)]);
        sprite.HideSprite(SpriteType.Hair2);
        if (bellySize < 3)
        {
            clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.RainCoats[heavyWeight ? 7 : 6];
        }
        else if (bellySize < 8)
            clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.RainCoats[8];
        else if (bellySize < 11)
            clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.RainCoats[9];
        else if (bellySize < 14)
            clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.RainCoats[10];
        else if (bellySize < 16)
            clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.RainCoats[11];
        if (actor.Unit.HasBreasts == false || actor.Unit.BreastSize == 0)
            clothing3.GetSprite = null;
        else
        {
            clothing3.GetSprite = (s) => State.GameManager.SpriteDictionary.RainCoats[11 + actor.Unit.BreastSize];
        }
        clothing4.GetSprite = (s) => State.GameManager.SpriteDictionary.RainCoats[4];


        base.Configure(sprite, actor);
    }
}

class TigerSpecial : MainClothing
{
    public TigerSpecial()
    {
        coversBreasts = false;
        blocksBreasts = true;
        OccupiesAllSlots = true;
        Type = 90;
        clothing1 = new SpriteExtraInfo(10, null, null);
        clothing2 = new SpriteExtraInfo(18, null, null);
        clothing3 = new SpriteExtraInfo(12, null, null);
        clothing4 = new SpriteExtraInfo(8, null, null);
        DiscardSprite = State.GameManager.SpriteDictionary.TigerSpecial[22];
        DiscardUsesPalettes = true;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.TigerSpecial[3 + actor.Unit.BodySize];
        clothing1.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.ClothingStrict, actor.Unit.ClothingColor);

        clothing2.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.ClothingStrict, actor.Unit.ClothingColor);
        if (actor.Unit.BreastSize >= 0)
            clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.TigerSpecial[11 + actor.Unit.BreastSize];
        else
            clothing2.GetSprite = null;

        if (Config.FurryHandsAndFeet || actor.Unit.Furry)
            clothing3.GetSprite = null;
        else
            clothing3.GetSprite = (s) => State.GameManager.SpriteDictionary.TigerSpecial[2];

        if (actor.Unit.BreastSize > 4)
        {
            breastSprite = State.GameManager.SpriteDictionary.TigerSpecial[14 + actor.Unit.BreastSize];
            blocksBreasts = false;
        }
        else
        {
            blocksBreasts = true;
        }
        clothing4.GetSprite = (s) => State.GameManager.SpriteDictionary.TigerSpecial[actor.IsAttacking ? 1 : 0];
        clothing4.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.ClothingStrict, actor.Unit.ClothingColor);
        sprite.HideSprite(SpriteType.Weapon);

        base.Configure(sprite, actor);
    }

}

class CatLeader : MainClothing
{
    public CatLeader()
    {
        leaderOnly = true;
        OccupiesAllSlots = true;
        coversBreasts = false;
        clothing1 = new SpriteExtraInfo(10, null, null);
        clothing2 = new SpriteExtraInfo(11, null, null);
        clothing3 = new SpriteExtraInfo(19, null, null);
        clothing4 = new SpriteExtraInfo(18, null, null);
        clothing5 = new SpriteExtraInfo(9, null, null);
        clothing6 = new SpriteExtraInfo(9, null, null);
        Type = 91;
        DiscardSprite = State.GameManager.SpriteDictionary.CatLeader[4];
        HidesFluff = true;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        //int bodyMod = actor.Unit.BodySize + (actor.Unit.HasBreasts ? 0 : 4);
        int bodyMod = actor.Unit.BodySize + (actor.Unit.HasBreasts ? 0 : 4);
        if (actor.Unit.BodySize == 0)
            bodyMod = 0;
        if (bodyMod > 7)
            bodyMod = 7;
        bool furryArms = actor.Unit.Furry || Config.FurryHandsAndFeet;
        clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.CatLeader[(furryArms ? 0 : 2) + (actor.IsAttacking ? 1 : 0)];
        clothing1.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.ClothingStrict, actor.Unit.ClothingColor);
        clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.CatLeader[6 + bodyMod];
        clothing2.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.ClothingStrict, actor.Unit.ClothingColor);
        if (actor.Unit.BreastSize < 1)
            clothing3.GetSprite = null;
        else
            clothing3.GetSprite = (s) => State.GameManager.SpriteDictionary.CatLeader[13 + actor.Unit.BreastSize];

        actor.SquishedBreasts = true;

        if (actor.Unit.BreastSize < 6)
        {
            clothing4.GetSprite = (s) => State.GameManager.SpriteDictionary.CatLeader[21 + bodyMod];
            clothing5.GetSprite = (s) => State.GameManager.SpriteDictionary.CatLeader[29 + bodyMod];
        }
        else
        {
            clothing4.GetSprite = null;
            clothing5.GetSprite = null;
        }


        if (furryArms)
            clothing6.GetSprite = null;
        else
            clothing6.GetSprite = (s) => State.GameManager.SpriteDictionary.CatLeader[4];


        base.Configure(sprite, actor);
    }

}

class Toga : MainClothing
{
    public Toga()
    {
        clothing1 = new SpriteExtraInfo(17, null, WhiteColored);
        clothing2 = new SpriteExtraInfo(10, null, WhiteColored);
        DiscardSprite = State.GameManager.SpriteDictionary.Togas[10];
        DiscardUsesPalettes = true;
        Type = 230;
        OccupiesAllSlots = true;
        //These are there to counteract the lamias natural clothing offset
        clothing1.XOffset = 1.875f;
        clothing1.YOffset = -3.75f;
        clothing2.XOffset = 1.875f;
        clothing2.YOffset = -3.75f;

    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        //clothing1.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.ClothingStrict, actor.Unit.ClothingColor);
        //clothing2.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.ClothingStrict, actor.Unit.ClothingColor);
        clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.Togas[actor.Unit.HasBreasts ? (1 + actor.Unit.BreastSize) : 9];
        clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.Togas[0];
        base.Configure(sprite, actor);
    }
}

class SuccubusDress : MainClothing
{
    public SuccubusDress()
    {
        clothing1 = new SpriteExtraInfo(14, null, WhiteColored);
        clothing2 = new SpriteExtraInfo(17, null, WhiteColored);
        blocksDick = false;
        coversBreasts = false;
        DiscardSprite = State.GameManager.SpriteDictionary.SuccubusDress[22];
        DiscardUsesPalettes = true;
        Type = 233;
        OccupiesAllSlots = true;
        clothing1.YOffset = -32 * .625f;
        clothing2.YOffset = -32 * .625f;

    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        clothing1.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.ClothingStrictRedKey, actor.Unit.ClothingColor);
        clothing2.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.ClothingStrictRedKey, actor.Unit.ClothingColor);
        int spriteNum = 0;
        if (actor.IsUnbirthing || actor.IsAnalVoring)
            spriteNum = 1;
        else
        {
            if (actor.HasBelly)
                spriteNum = 2 + actor.GetStomachSize();
        }
        clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.SuccubusDress[spriteNum];
        if (actor.Unit.HasBreasts)
            clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.SuccubusDress[18 + actor.Unit.BreastSize];
        else
            clothing2.GetSprite = null;
        if (spriteNum < 7)
            sprite.ChangeLayer(SpriteType.Dick, 12);
        if (actor.GetBallSize(15) > 6 && spriteNum >= 8)
            base.ConfigureIgnoreHidingRules(sprite, actor);
        else
            base.Configure(sprite, actor);
    }
}

class SuccubusLeotard : MainClothing
{
    public SuccubusLeotard()
    {
        clothing1 = new SpriteExtraInfo(12, null, WhiteColored);
        clothing2 = new SpriteExtraInfo(14, null, WhiteColored);
        clothing3 = new SpriteExtraInfo(6, null, WhiteColored);
        clothing4 = new SpriteExtraInfo(14, null, WhiteColored);
        clothing5 = new SpriteExtraInfo(17, null, WhiteColored);
        coversBreasts = false;
        DiscardSprite = State.GameManager.SpriteDictionary.SuccubusLeotard[36];
        DiscardUsesPalettes = true;
        Type = 234;
        OccupiesAllSlots = true;
        clothing1.YOffset = -32 * .625f;
        clothing2.YOffset = -32 * .625f;
        clothing3.YOffset = -32 * .625f;
        clothing4.YOffset = -32 * .625f;
        clothing5.YOffset = -32 * .625f;

    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        clothing1.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.ClothingStrictRedKey, actor.Unit.ClothingColor2);
        clothing2.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.ClothingStrictRedKey, actor.Unit.ClothingColor2);
        clothing3.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.ClothingStrictRedKey, actor.Unit.ClothingColor2);
        clothing4.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.ClothingStrictRedKey, actor.Unit.ClothingColor);
        clothing5.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.ClothingStrictRedKey, actor.Unit.ClothingColor);
        int spriteNum = actor.GetStomachSize();
        if (actor.IsUnbirthing || actor.IsAnalVoring)
        {
            clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.SuccubusLeotard[1];
            if (spriteNum < 10)
                clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.SuccubusLeotard[25 + spriteNum];
            else
                clothing2.GetSprite = null;
            clothing3.GetSprite = null;
            if (actor.HasBelly)
                clothing4.GetSprite = (s) => State.GameManager.SpriteDictionary.SuccubusLeotard[4 + spriteNum];
        }
        else
        {
            clothing3.GetSprite = (s) => State.GameManager.SpriteDictionary.SuccubusLeotard[actor.IsAttacking ? 3 : 2];
            clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.SuccubusLeotard[0];
            if (actor.HasBelly)
            {
                clothing4.GetSprite = (s) => State.GameManager.SpriteDictionary.SuccubusLeotard[4 + spriteNum];
                if (spriteNum < 10)
                    clothing2.GetSprite = (s) => State.GameManager.SpriteDictionary.SuccubusLeotard[25 + spriteNum];
                else
                    clothing2.GetSprite = null;
            }
            else
            {
                clothing2.GetSprite = null;
                clothing4.GetSprite = (s) => State.GameManager.SpriteDictionary.SuccubusLeotard[4];
            }
        }
        if (actor.Unit.HasBreasts)
            clothing5.GetSprite = (s) => State.GameManager.SpriteDictionary.SuccubusLeotard[21 + actor.Unit.BreastSize];
        else
            clothing5.GetSprite = null;
        base.Configure(sprite, actor);
    }
}

class LizardBlackTop : MainClothing
{
    public LizardBlackTop()
    {
        DiscardSprite = null;
        blocksBreasts = true;
        blocksDick = false;
        Type = 208;
        FixedColor = true;
        clothing1 = new SpriteExtraInfo(17, null, WhiteColored);
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {

        if (actor.Unit.HasBreasts)
        {
            clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardBlackTop[actor.Unit.BreastSize];
        }
        else
        {
            clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardBlackTop[0];
        }

        base.Configure(sprite, actor);
    }
}

class LizardBikiniTop : MainClothing
{
    public LizardBikiniTop()
    {
        DiscardSprite = State.GameManager.SpriteDictionary.BikiniTop[9];
        femaleOnly = true;
        coversBreasts = false;
        blocksDick = false;
        clothing1 = new SpriteExtraInfo(17, null, null);
        Type = 205;
        DiscardUsesPalettes = true;
    }


    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {
        if (actor.Unit.HasBreasts)
        {
            clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardBikiniTop[actor.Unit.BreastSize];
            actor.SquishedBreasts = true;
            clothing1.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.Clothing, actor.Unit.ClothingColor);
        }
        else
        {
            clothing1.GetSprite = null;
        }

        base.Configure(sprite, actor);
    }
}

class LizardStrapTop : MainClothing
{
    public LizardStrapTop()
    {
        DiscardSprite = State.GameManager.SpriteDictionary.Straps[9];
        femaleOnly = true;
        coversBreasts = false;
        blocksDick = false;
        Type = 204;
        clothing1 = new SpriteExtraInfo(17, null, null);
        DiscardUsesPalettes = true;
    }

    public override void Configure(CompleteSprite sprite, Actor_Unit actor)
    {

        if (actor.Unit.HasBreasts)
        {
            clothing1.GetSprite = (s) => State.GameManager.SpriteDictionary.LizardCrossTop[actor.Unit.BreastSize];
            clothing1.GetPalette = (s) => ColorPaletteMap.GetPalette(ColorPaletteMap.SwapType.Clothing, actor.Unit.ClothingColor);
            actor.SquishedBreasts = true;
        }
        else
        {
            clothing1.GetSprite = null;
        }

        base.Configure(sprite, actor);
    }
}

static class RaceSpecificClothing
{

    internal static LizardPeasant LizardPeasant = new LizardPeasant();
    internal static LizardBlackTop LizardBlackTop = new LizardBlackTop();
    internal static LizardBikiniTop LizardBikiniTop = new LizardBikiniTop();
    internal static LizardStrapTop LizardStrapTop = new LizardStrapTop();

    internal static LizardLeaderCrown LizardLeaderCrown = new LizardLeaderCrown();
    internal static LizardLeaderTop LizardLeaderTop = new LizardLeaderTop();
    internal static LizardLeaderSkirt LizardLeaderSkirt = new LizardLeaderSkirt();
    internal static LizardLeaderLegguards LizardLeaderLegguards = new LizardLeaderLegguards();
    internal static LizardLeaderArmbands LizardLeaderArmbands = new LizardLeaderArmbands();

    internal static LizardBoneCrown LizardBoneCrown = new LizardBoneCrown();
    internal static LizardBoneTop LizardBoneTop = new LizardBoneTop();
    internal static LizardBoneLoins LizardBoneLoins = new LizardBoneLoins();
    internal static LizardBoneLegguards LizardBoneLegguards = new LizardBoneLegguards();
    internal static LizardBoneArmbands1 LizardBoneArmbands1 = new LizardBoneArmbands1();
    internal static LizardBoneArmbands2 LizardBoneArmbands2 = new LizardBoneArmbands2();
    internal static LizardBoneArmbands3 LizardBoneArmbands3 = new LizardBoneArmbands3();

    internal static LizardLeatherCrown LizardLeatherCrown = new LizardLeatherCrown();
    internal static LizardLeatherTop LizardLeatherTop = new LizardLeatherTop();
    internal static LizardLeatherLoins LizardLeatherLoins = new LizardLeatherLoins();
    internal static LizardLeatherLegguards LizardLeatherLegguards = new LizardLeatherLegguards();
    internal static LizardLeatherArmbands1 LizardLeatherArmbands1 = new LizardLeatherArmbands1();
    internal static LizardLeatherArmbands2 LizardLeatherArmbands2 = new LizardLeatherArmbands2();
    internal static LizardLeatherArmbands3 LizardLeatherArmbands3 = new LizardLeatherArmbands3();

    internal static LizardClothCrown LizardClothCrown = new LizardClothCrown();
    internal static LizardClothTop LizardClothTop = new LizardClothTop();
    internal static LizardClothLoins LizardClothLoins = new LizardClothLoins();
    internal static LizardClothShorts LizardClothShorts = new LizardClothShorts();
    internal static LizardClothArmbands1 LizardClothArmbands1 = new LizardClothArmbands1();
    internal static LizardClothArmbands2 LizardClothArmbands2 = new LizardClothArmbands2();
    internal static LizardClothArmbands3 LizardClothArmbands3 = new LizardClothArmbands3();
    internal static RainCoat RainCoat = new RainCoat();
    internal static TigerSpecial TigerSpecial = new TigerSpecial();
    internal static CatLeader CatLeader = new CatLeader();
    internal static Toga Toga = new Toga();
    internal static SuccubusDress SuccubusDress = new SuccubusDress();
    internal static SuccubusLeotard SuccubusLeotard = new SuccubusLeotard();


    internal static List<MainClothing> All = new List<MainClothing>()
    {
        LizardPeasant,
        LizardBlackTop,
        LizardBikiniTop,
        LizardStrapTop,
        LizardLeaderTop,
        LizardLeaderSkirt,
        LizardLeaderLegguards,
        LizardLeaderArmbands,
        LizardBoneTop,
        LizardBoneLoins,
        LizardBoneLegguards,
        LizardBoneArmbands1,
        LizardBoneArmbands2,
        LizardBoneArmbands3,
        LizardLeatherTop,
        LizardLeatherLoins,
        LizardLeatherLegguards,
        LizardLeatherArmbands1,
        LizardLeatherArmbands2,
        LizardLeatherArmbands3,
        LizardClothTop,
        LizardClothLoins,
        LizardClothShorts,
        LizardClothArmbands1,
        LizardClothArmbands2,
        LizardClothArmbands3,
        RainCoat,
        TigerSpecial,
        CatLeader,
        Toga,
        SuccubusDress,
        SuccubusLeotard,
    };
    internal static List<ClothingAccessory> Uhh = new List<ClothingAccessory>()
    {
        LizardLeaderCrown,
        LizardBoneCrown,
        LizardLeatherCrown,
        LizardClothCrown,
    };

}



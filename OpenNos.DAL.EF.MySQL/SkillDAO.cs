﻿/*
 * This file is part of the OpenNos Emulator Project. See AUTHORS file for Copyright information
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 */

using AutoMapper;
using OpenNos.DAL.EF.MySQL.DB;
using OpenNos.DAL.EF.MySQL.Helpers;
using OpenNos.DAL.Interface;
using OpenNos.Data;
using System.Collections.Generic;
using System.Linq;

namespace OpenNos.DAL.EF.MySQL
{
    public class SkillDAO : ISkillDAO
    {
        #region Methods

        public void Insert(List<SkillDTO> skills)
        {
            using (var context = DataAccessHelper.CreateContext())
            {

                context.Configuration.AutoDetectChangesEnabled = false;
                foreach (SkillDTO skill in skills)
                {
                    Skill entity = Mapper.Map<Skill>(skill);
                    context.skill.Add(entity);
                }
                context.SaveChanges();

            }
        }

        public SkillDTO Insert(SkillDTO skill)
        {
            using (var context = DataAccessHelper.CreateContext())
            {
                Skill entity = Mapper.Map<Skill>(skill);
                context.skill.Add(entity);
                context.SaveChanges();
                return Mapper.Map<SkillDTO>(entity);
            }
        }

        public SkillDTO LoadById(short SkillId)
        {
            using (var context = DataAccessHelper.CreateContext())
            {
                return Mapper.Map<SkillDTO>(context.skill.FirstOrDefault(s => s.SkillVNum.Equals(SkillId)));
            }
        }

        #endregion
    }
}
﻿// Copyright 2015 XLGAMES Inc.
//
// Distributed under the MIT License (See
// accompanying file "LICENSE" or the website
// http://www.opensource.org/licenses/mit-license.php)

using System;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using System.Collections.Generic;

using Sce.Atf;
using Sce.Atf.Applications;
using Sce.Atf.VectorMath;

using LevelEditorCore;

namespace LevelEditorXLE.Services
{
    [Export(typeof(IInitializable))]
    [Export(typeof(Commands))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class Commands : ICommandClient, IInitializable
    {
        public bool CanDoCommand(object commandTag)
        {
            if (!(commandTag is Command))
                return false;

            switch ((Command)commandTag)
            {
                case Command.SaveModifiedAssets:
                    return GUILayer.PendingSaveList.HasModifiedAssets();

                case Command.ViewInvalidAssets:
                    return true;
            }

            return false;
        }

        public void DoCommand(object commandTag)
        {
            if (commandTag is Command)
            {
                switch ((Command)commandTag)
                {
                    case Command.SaveModifiedAssets:
                        PerformSaveModifiedAssets();
                        break;

                    case Command.ViewInvalidAssets:
                        PerformViewInvalidAssets();
                        break;
                }
            }
        }

        public void UpdateCommand(object commandTag, Sce.Atf.Applications.CommandState state)
        {
            // if (commandTag is Command)
            // {
            //     switch ((Command)commandTag)
            //     {
            //     }
            // }
        }

        public virtual void Initialize()
        {
            m_commandService.RegisterCommand(
                Command.SaveModifiedAssets,
                StandardMenu.File,
                "Assets",
                "Modified Assets...".Localize(),
                "View and save any assets that have been modified".Localize(),
                Keys.None,
                LevelEditorCore.Resources.CubesImage,
                CommandVisibility.Menu,
                this);

            m_commandService.RegisterCommand(
                Command.ViewInvalidAssets,
                StandardMenu.File,
                "Assets",
                "View Invalid Assets...".Localize(),
                "View any assets at are marked as invalid".Localize(),
                Keys.None,
                LevelEditorCore.Resources.CubesImage,
                CommandVisibility.Menu,
                this);
        }

        private enum Command
        {
            SaveModifiedAssets,
            ViewInvalidAssets
        }

        private void PerformSaveModifiedAssets()
        {
            var pendingAssetList = GUILayer.PendingSaveList.Create();
            using (var dialog = new ControlsLibrary.ModifiedAssetsDialog())
            {
                dialog.BuildAssetList(pendingAssetList);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pendingAssetList.Commit();
                }
            }
        }

        private void PerformViewInvalidAssets()
        {
            using (var dialog = new ControlsLibrary.InvalidAssetDialog())
            {
                dialog.ShowDialog();
            }
        }

        [Import(AllowDefault = false)]
        private ICommandService m_commandService;
    }
}
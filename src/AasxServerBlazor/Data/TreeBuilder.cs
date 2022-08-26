﻿using AasxServer;
using AasxServerBlazor.Models;
using Aml.Engine.CAEX;
using System;
using System.Collections.Generic;
using System.IO;
using static AasxServerBlazor.Pages.TreePage;
using static AdminShellNS.AdminShellV20;

namespace AasxServerBlazor.Data
{
    public class TreeBuilder
    {
        public List<TreeNodeData> BuildTree()
        {
            List<TreeNodeData> viewItems = new List<TreeNodeData>();

            for (int i = 0; i < Program.env.Count; i++)
            {
                TreeNodeData root = new TreeNodeData();
                root.EnvIndex = i;
                if (Program.env[i] != null)
                {
                    root.Text = Program.env[i].AasEnv.AdministrationShells[0].idShort;
                    root.Tag = Program.env[i].AasEnv.AdministrationShells[0];
                    CreateViewFromAASEnv(root, Program.env[i].AasEnv, i);
                    viewItems.Add(root);
                }
            }

            return viewItems;
        }

        private void CreateViewFromAASEnv(TreeNodeData root, AdministrationShellEnv aasEnv, int i)
        {
            List<TreeNodeData> subModelTreeNodeDataList = new List<TreeNodeData>();
            foreach (Submodel subModel in aasEnv.Submodels)
            {
                if (subModel != null && subModel.idShort != null)
                {
                    TreeNodeData subModelTreeNodeData = new TreeNodeData();
                    subModelTreeNodeData.EnvIndex = i;
                    subModelTreeNodeData.Text = subModel.idShort;
                    subModelTreeNodeData.Tag = subModel;
                    subModelTreeNodeDataList.Add(subModelTreeNodeData);
                    CreateViewFromSubModel(subModelTreeNodeData, subModel, i);
                }
            }

            root.Children = subModelTreeNodeDataList;

            foreach (TreeNodeData nodeData in subModelTreeNodeDataList)
            {
                nodeData.Parent = root;
            }
        }

        private void CreateViewFromSubModel(TreeNodeData rootItem, Submodel subModel, int i)
        {
            List<TreeNodeData> subModelElementTreeNodeDataList = new List<TreeNodeData>();
            foreach (SubmodelElementWrapper subModelElementWrapper in subModel.submodelElements)
            {
                TreeNodeData subModelElementTreeNodeData = new TreeNodeData();
                subModelElementTreeNodeData.EnvIndex = i;
                subModelElementTreeNodeData.Text = subModelElementWrapper.submodelElement.idShort;
                subModelElementTreeNodeData.Tag = subModelElementWrapper.submodelElement;
                subModelElementTreeNodeDataList.Add(subModelElementTreeNodeData);

                if (subModelElementWrapper.submodelElement is SubmodelElementCollection)
                {
                    SubmodelElementCollection submodelElementCollection = subModelElementWrapper.submodelElement as SubmodelElementCollection;
                    CreateViewFromSubModelElementCollection(subModelElementTreeNodeData, submodelElementCollection, i);
                }

                if (subModelElementWrapper.submodelElement is Operation)
                {
                    Operation operation = subModelElementWrapper.submodelElement as Operation;
                    CreateViewFromOperation(subModelElementTreeNodeData, operation, i);
                }

                if (subModelElementWrapper.submodelElement is Entity)
                {
                    Entity entity = subModelElementWrapper.submodelElement as Entity;
                    CreateViewFromEntity(subModelElementTreeNodeData, entity, i);
                }

                if (subModelElementWrapper.submodelElement.idShort == "CAEX" || subModelElementWrapper.submodelElement.idShort == "AMLFile")

                {
                    CreateViewFromAMLCAEXFile(subModelElementTreeNodeData, subModelElementWrapper.submodelElement.ValueAsText(), i);
                }
            }

            rootItem.Children = subModelElementTreeNodeDataList;

            foreach (TreeNodeData nodeData in subModelElementTreeNodeDataList)
            {
                nodeData.Parent = rootItem;
            }
        }

        private void CreateViewFromSubModelElementCollection(TreeNodeData rootItem, SubmodelElementCollection subModelElementCollection, int i)
        {
            List<TreeNodeData> treeNodeDataList = new List<TreeNodeData>();
            foreach (SubmodelElementWrapper subModelElementWrapper in subModelElementCollection.value)
            {
                if (subModelElementWrapper != null && subModelElementWrapper.submodelElement != null)
                {
                    TreeNodeData smeItem = new TreeNodeData();
                    smeItem.EnvIndex = i;
                    smeItem.Text = subModelElementWrapper.submodelElement.idShort;
                    smeItem.Tag = subModelElementWrapper.submodelElement;
                    treeNodeDataList.Add(smeItem);

                    if (subModelElementWrapper.submodelElement is SubmodelElementCollection)
                    {
                        SubmodelElementCollection smecNext = subModelElementWrapper.submodelElement as SubmodelElementCollection;
                        CreateViewFromSubModelElementCollection(smeItem, smecNext, i);
                    }

                    if (subModelElementWrapper.submodelElement is Operation)
                    {
                        Operation operation = subModelElementWrapper.submodelElement as Operation;
                        CreateViewFromOperation(smeItem, operation, i);
                    }

                    if (subModelElementWrapper.submodelElement is Entity)
                    {
                        Entity entity = subModelElementWrapper.submodelElement as Entity;
                        CreateViewFromEntity(smeItem, entity, i);
                    }

                    if ((subModelElementWrapper.submodelElement.idShort == "NODESET2_XML")
                    && Uri.IsWellFormedUriString(subModelElementWrapper.submodelElement.ValueAsText(), UriKind.Absolute))
                    {
                        CreateViewFromUACloudLibraryNodeset(smeItem, new Uri(subModelElementWrapper.submodelElement.ValueAsText()), i);
                    }

                    if (subModelElementWrapper.submodelElement.idShort == "CAEX" || subModelElementWrapper.submodelElement.idShort == "AMLFile")

                    {
                        CreateViewFromAMLCAEXFile(smeItem, subModelElementWrapper.submodelElement.ValueAsText(), i);
                    }

                    if(subModelElementWrapper.submodelElement is RelationshipElement)
                    {
                        if(subModelElementWrapper.submodelElement.idShort == "RefToInternalElementInAML")
                        {
                            CreateViewFromRefToInternalElementInAML(smeItem, (RelationshipElement)subModelElementWrapper.submodelElement, i);
                        } else if (subModelElementWrapper.submodelElement.idShort == "RefToAttrbuteInAML")
                        {
                            CreateViewFromRefToAttrbuteInAML(smeItem, (RelationshipElement)subModelElementWrapper.submodelElement, i);
                        } else
                        {
                            //Nothing to do for now
                        }
                    }
                }
            }

            rootItem.Children = treeNodeDataList;

            foreach (TreeNodeData nodeData in treeNodeDataList)
            {
                nodeData.Parent = rootItem;
            }
        }

        private void CreateViewFromRefToInternalElementInAML(TreeNodeData rootItem, RelationshipElement refToInternalElement, int i)
        {

            //refToInternalElement.second

            

            List<TreeNodeData> treeNodeDataList = new List<TreeNodeData>();
            TreeNodeData smeItem;
            foreach (Key k in refToInternalElement.first.Keys)
            {
                

                if (k.idType == "Custom" && k.value.StartsWith("AML@id"))
                {
                    smeItem = new TreeNodeData();
                    smeItem.EnvIndex = i;
                    smeItem.Text = k.idType + " - " + k.value;
                    smeItem.Type = "AML Link";
                    smeItem.Tag = new SubmodelElement() { idShort = k.value };
                    smeItem.Children = new List<TreeNodeData>();
                    treeNodeDataList.Add(smeItem);
                    Aml.Engine.Services.QueryService qservice = new Aml.Engine.Services.QueryService();
                    CAEXObject obj = qservice.FindByID(doc, k.value.Replace("AML@id=", ""));
                    if(obj != null && obj is InternalElementType)
                    {
                        CreateViewFromInternalElement(smeItem, (List<TreeNodeData>)smeItem.Children, (InternalElementType)obj, i);
                    }
                }
            }

            string aas_ref = "";
            foreach (Key k in refToInternalElement.second.Keys)
            {
                aas_ref += k.value + " ";
            }

            smeItem = new TreeNodeData();
            smeItem.EnvIndex = i;
            smeItem.Text = aas_ref;
            smeItem.Type = "AAS Link";
            smeItem.Tag = new SubmodelElement() { idShort = aas_ref };
            smeItem.Children = new List<TreeNodeData>();
            treeNodeDataList.Add(smeItem);

            rootItem.Children = treeNodeDataList;


        }

        private void CreateViewFromRefToAttrbuteInAML(TreeNodeData rootItem, RelationshipElement RefToAttrbuteInAML, int i)
        {

            //refToInternalElement.second

            
            List<TreeNodeData> treeNodeDataList = new List<TreeNodeData>();

            TreeNodeData smeItem;
            foreach (Key k in RefToAttrbuteInAML.first.Keys)
            {
                if (k.idType == "Custom" && k.value.StartsWith("AML@id"))
                {
                    smeItem = new TreeNodeData();
                    smeItem.EnvIndex = i;
                    smeItem.Text = k.idType + " - " + k.value;
                    smeItem.Type = "AML Link";
                    smeItem.Tag = new SubmodelElement() { idShort = k.value };
                    smeItem.Children = new List<TreeNodeData>();
                    treeNodeDataList.Add(smeItem);

                
                    string tmp = k.value.Replace("AML@id=", "");
                    int idx = tmp.IndexOf(".");
                    string id = tmp.Substring(0, idx);
                    string attrName = tmp.Replace(id + ".", "");

                    Aml.Engine.Services.QueryService qservice = new Aml.Engine.Services.QueryService();
                    CAEXObject obj = qservice.FindByID(doc, id);
                    if(obj != null && obj is InternalElementType)
                    {
                        AttributeType attr = ((InternalElementType)obj).Attribute[attrName];
                        if(attr != null)
                        {
                            CreateViewFromAmlAttribute(smeItem, (List<TreeNodeData>) smeItem.Children, attr, i);
                        }
                    }
                }
            }

            string aas_ref = "";
            foreach (Key k in RefToAttrbuteInAML.second.Keys)
            {
                aas_ref += k.value + " ";
            }

            smeItem = new TreeNodeData();
            smeItem.EnvIndex = i;
            smeItem.Text = aas_ref;
            smeItem.Type = "AAS Link";
            smeItem.Tag = new SubmodelElement() { idShort = aas_ref };
            smeItem.Children = new List<TreeNodeData>();
            treeNodeDataList.Add(smeItem);

            rootItem.Children = treeNodeDataList;


        }

        //ToDo Now assume that his was called before the references and that this file exsists.
        CAEXDocument doc = null;
        private void CreateViewFromAMLCAEXFile(TreeNodeData rootItem, string filename, int i)
        {
            try
            {
                Stream packagePartStream = Program.env[i].GetLocalStreamFromPackage(filename);
                doc = CAEXDocument.LoadFromStream(packagePartStream);
                List<TreeNodeData> treeNodeDataList = new List<TreeNodeData>();

                

                foreach (var instanceHirarchy in doc.CAEXFile.InstanceHierarchy)
                {
                    TreeNodeData smeItem = new TreeNodeData();
                    smeItem.EnvIndex = i;
                    smeItem.Text = instanceHirarchy.ID;
                    smeItem.Type = "AML IH";
                    smeItem.Tag = new SubmodelElement() { idShort = instanceHirarchy.Name };
                    smeItem.Children = new List<TreeNodeData>();
                    treeNodeDataList.Add(smeItem);

                    foreach (var internalElement in instanceHirarchy.InternalElement)
                    {
                        CreateViewFromInternalElement(smeItem, (List<TreeNodeData>)smeItem.Children, internalElement, i);
                    }
                }

                foreach (var roleclassLib in doc.CAEXFile.RoleClassLib)
                {
                    TreeNodeData smeItem = new TreeNodeData();
                    smeItem.EnvIndex = i;
                    smeItem.Text = roleclassLib.ID;
                    smeItem.Type = "AML RCL";
                    smeItem.Tag = new SubmodelElement() { idShort = roleclassLib.Name };
                    smeItem.Children = new List<TreeNodeData>();
                    treeNodeDataList.Add(smeItem);

                    foreach (RoleFamilyType roleClass in roleclassLib.RoleClass)
                    {
                        CreateViewFromRoleClasses(smeItem, (List<TreeNodeData>)smeItem.Children, roleClass, i);
                    }
                }

                foreach (var systemUnitClassLib in doc.CAEXFile.SystemUnitClassLib)
                {
                    TreeNodeData smeItem = new TreeNodeData();
                    smeItem.EnvIndex = i;
                    smeItem.Text = systemUnitClassLib.ID;
                    smeItem.Type = "AML SUCL";
                    smeItem.Tag = new SubmodelElement() { idShort = systemUnitClassLib.Name };
                    smeItem.Children = new List<TreeNodeData>();
                    treeNodeDataList.Add(smeItem);

                    foreach (SystemUnitFamilyType systemUnitClass in systemUnitClassLib.SystemUnitClass)
                    {
                        CreateViewFromSystemUnitClasses(smeItem, (List<TreeNodeData>)smeItem.Children, systemUnitClass, i);
                    }
                }

                rootItem.Children = treeNodeDataList;

                foreach (TreeNodeData nodeData in treeNodeDataList)
                {
                    nodeData.Parent = rootItem;
                }
            }
            catch (Exception ex)
            {
                // ignore this node
                Console.WriteLine(ex);
            }
        }

        private void CreateViewFromInternalElement(TreeNodeData rootItem, List<TreeNodeData> rootItemChildren, InternalElementType internalElement, int i)
        {
            TreeNodeData smeItem = new TreeNodeData();
            smeItem.EnvIndex = i;
            smeItem.Text = internalElement.ID;
            smeItem.Type = "AML IE";
            smeItem.Tag = new SubmodelElement() { idShort = internalElement.Name };
            smeItem.Parent = rootItem;
            smeItem.Children = new List<TreeNodeData>();
            rootItemChildren.Add(smeItem);

            //Displaying the assigned role classes for this internal element also in the tree view.
            CreateViewFromAssignedRoleClasses(smeItem, (List<TreeNodeData>)smeItem.Children, internalElement, i);

            foreach(AttributeType attribute in internalElement.Attribute)
            {
                CreateViewFromAmlAttribute(smeItem, (List<TreeNodeData>)smeItem.Children, attribute, i);
            }

            foreach (InternalElementType childInternalElement in internalElement.InternalElement)
            {
                CreateViewFromInternalElement(smeItem, (List<TreeNodeData>)smeItem.Children, childInternalElement, i);
            }
        }

        private void CreateViewFromAssignedRoleClasses(TreeNodeData rootItem, List<TreeNodeData> rootItemChildren, InternalElementType internalElement, int i)
        {
            
            foreach(RoleRequirementsType rc in internalElement.RoleRequirements)
            {
                TreeNodeData smeItem = new TreeNodeData();
                smeItem.EnvIndex = i;
                smeItem.Text = rc.RoleClass.Name;
                smeItem.Type = "RoleReq";
                smeItem.Tag = new SubmodelElement() { idShort = rc.RoleClass.Name };
                rootItemChildren.Add(smeItem);
            }
            
            foreach(SupportedRoleClassType rc in internalElement.SupportedRoleClass)
            {
                TreeNodeData smeItem = new TreeNodeData();
                smeItem.EnvIndex = i;
                smeItem.Text = rc.RoleClass.Name;
                smeItem.Type = "SupportedRC";
                smeItem.Tag = new SubmodelElement() { idShort = rc.RoleClass.Name };
                rootItemChildren.Add(smeItem);
            }
        }

        private void CreateViewFromAmlAttribute(TreeNodeData rootItem, List<TreeNodeData> rootItemChildren, AttributeType attribute, int i)
        {
            TreeNodeData smeItem = new TreeNodeData();
            smeItem.EnvIndex = i;
            smeItem.Text = attribute.Name + " = " + attribute.Value;
            smeItem.Type = "AML ATTR";
            smeItem.Tag = new SubmodelElement() { idShort = attribute.Name + " = " + attribute.Value };
            smeItem.Parent = rootItem;
            smeItem.Children = new List<TreeNodeData>();
            rootItemChildren.Add(smeItem);

            foreach (AttributeType attributeType in attribute.Attribute)
            {
                CreateViewFromAmlAttribute(smeItem, (List<TreeNodeData>)smeItem.Children, attributeType, i);
            }

            
        }

        private void CreateViewFromRoleClasses(TreeNodeData rootItem, List<TreeNodeData> rootItemChildren, RoleFamilyType roleClass, int i)
        {
            TreeNodeData smeItem = new TreeNodeData();
            smeItem.EnvIndex = i;
            smeItem.Text = roleClass.ID;
            smeItem.Type = "AML RC";
            smeItem.Tag = new SubmodelElement() { idShort = roleClass.Name };
            smeItem.Parent = rootItem;
            smeItem.Children = new List<TreeNodeData>();
            rootItemChildren.Add(smeItem);

            foreach (RoleFamilyType childRoleClass in roleClass.RoleClass)
            {
                CreateViewFromRoleClasses(smeItem, (List<TreeNodeData>)smeItem.Children, childRoleClass, i);
            }
        }

        private void CreateViewFromSystemUnitClasses(TreeNodeData rootItem, List<TreeNodeData> rootItemChildren, SystemUnitFamilyType systemUnitClass, int i)
        {
            TreeNodeData smeItem = new TreeNodeData();
            smeItem.EnvIndex = i;
            smeItem.Text = systemUnitClass.ID;
            smeItem.Type = "AML SUC";
            smeItem.Tag = new SubmodelElement() { idShort = systemUnitClass.Name };
            smeItem.Parent = rootItem;
            smeItem.Children = new List<TreeNodeData>();
            rootItemChildren.Add(smeItem);

            foreach (InternalElementType childInternalElement in systemUnitClass.InternalElement)
            {
                CreateViewFromInternalElement(smeItem, (List<TreeNodeData>)smeItem.Children, childInternalElement, i);
            }

            foreach (SystemUnitFamilyType childSystemUnitClass in systemUnitClass.SystemUnitClass)
            {
                CreateViewFromSystemUnitClasses(smeItem, (List<TreeNodeData>)smeItem.Children, childSystemUnitClass, i);
            }
        }

        private void CreateViewFromUACloudLibraryNodeset(TreeNodeData rootItem, Uri uri, int i)
        {
            try
            {
                UANodesetViewer viewer = new UANodesetViewer();
                viewer.Login(uri.AbsoluteUri, Environment.GetEnvironmentVariable("UACLUsername"), Environment.GetEnvironmentVariable("UACLPassword"));

                NodesetViewerNode rootNode = viewer.GetRootNode().GetAwaiter().GetResult();
                if ((rootNode != null) && rootNode.Children)
                {
                    CreateViewFromUANode(rootItem, viewer, rootNode, i);
                }

                viewer.Disconnect();
            }
            catch (Exception ex)
            {
                // ignore this part of the AAS
                Console.WriteLine(ex);
            }
        }

        private void CreateViewFromUANode(TreeNodeData rootItem, UANodesetViewer viewer, NodesetViewerNode rootNode, int i)
        {
            try
            {
                List<TreeNodeData> treeNodeDataList = new List<TreeNodeData>();
                List<NodesetViewerNode> children = viewer.GetChildren(rootNode.Id).GetAwaiter().GetResult();
                foreach (NodesetViewerNode node in children)
                {
                    TreeNodeData smeItem = new TreeNodeData();
                    smeItem.EnvIndex = i;
                    smeItem.Text = node.Text;
                    smeItem.Type = "UANode";
                    smeItem.Tag = new SubmodelElement() { idShort = node.Text };
                    treeNodeDataList.Add(smeItem);

                    if (node.Children)
                    {
                        CreateViewFromUANode(smeItem, viewer, node, i);
                    }
                }

                rootItem.Children = treeNodeDataList;

                foreach (TreeNodeData nodeData in treeNodeDataList)
                {
                    nodeData.Parent = rootItem;
                }
            }
            catch (Exception ex)
            {
                // ignore this node
                Console.WriteLine(ex);
            }
        }

        private void CreateViewFromOperation(TreeNodeData rootItem, Operation operation, int i)
        {
            List<TreeNodeData> treeNodeDataList = new List<TreeNodeData>();
            foreach (OperationVariable v in operation.inputVariable)
            {
                TreeNodeData smeItem = new TreeNodeData();
                smeItem.EnvIndex = i;
                smeItem.Text = v.value.submodelElement.idShort;
                smeItem.Type = "In";
                smeItem.Tag = v.value.submodelElement;
                treeNodeDataList.Add(smeItem);
            }

            foreach (OperationVariable v in operation.outputVariable)
            {
                TreeNodeData smeItem = new TreeNodeData();
                smeItem.EnvIndex = i;
                smeItem.Text = v.value.submodelElement.idShort;
                smeItem.Type = "Out";
                smeItem.Tag = v.value.submodelElement;
                treeNodeDataList.Add(smeItem);
            }

            foreach (OperationVariable v in operation.inoutputVariable)
            {
                TreeNodeData smeItem = new TreeNodeData();
                smeItem.EnvIndex = i;
                smeItem.Text = v.value.submodelElement.idShort;
                smeItem.Type = "InOut";
                smeItem.Tag = v.value.submodelElement;
                treeNodeDataList.Add(smeItem);
            }

            rootItem.Children = treeNodeDataList;

            foreach (TreeNodeData nodeData in treeNodeDataList)
            {
                nodeData.Parent = rootItem;
            }
        }

        private void CreateViewFromEntity(TreeNodeData rootItem, Entity entity, int i)
        {
            List<TreeNodeData> treeNodeDataList = new List<TreeNodeData>();
            foreach (SubmodelElementWrapper statement in entity.statements)
            {
                if (statement != null && statement.submodelElement != null)
                {
                    TreeNodeData smeItem = new TreeNodeData();
                    smeItem.EnvIndex = i;
                    smeItem.Text = statement.submodelElement.idShort;
                    smeItem.Type = "In";
                    smeItem.Tag = statement.submodelElement;
                    treeNodeDataList.Add(smeItem);
                }
            }

            rootItem.Children = treeNodeDataList;

            foreach (TreeNodeData nodeData in treeNodeDataList)
            {
                nodeData.Parent = rootItem;
            }
        }
    }
}
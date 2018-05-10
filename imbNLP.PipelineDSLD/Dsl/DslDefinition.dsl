<?xml version="1.0" encoding="utf-8"?>
<Dsl xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="c5113134-be15-47e3-8ef0-415290bb8772" Description="Description for imbNLP.PipelineDSLD.NLPPipelineDSLD" Name="NLPPipelineDSLD" DisplayName="NLPPipelineDSLD" Namespace="imbNLP.PipelineDSLD" ProductName="NLPPipelineDSLD" CompanyName="imbVeles" PackageGuid="c66e3f54-5765-4ab9-a0f5-d773c4063e00" PackageNamespace="imbNLP.PipelineDSLD" xmlns="http://schemas.microsoft.com/VisualStudio/2005/DslTools/DslDefinitionModel">
  <Classes>
    <DomainClass Id="60247645-52b9-450f-971b-d90482338105" Description="The root in which all other elements are embedded. Appears as a diagram." Name="PipelineModel" DisplayName="Pipeline Model" Namespace="imbNLP.PipelineDSLD">
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="OutputBinBase" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>PipelineModelHasOutputBinBases.OutputBinBases</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="PipelineNodeBase" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>PipelineModelHasPipelineNodeBases.PipelineNodeBases</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="3c8138c3-8a67-487b-8953-5b2dd908a800" Description="Elements embedded in the model. Appear as boxes on the diagram." Name="TaskConstructorBase" DisplayName="Task Constructor Base" Namespace="imbNLP.PipelineDSLD">
      <BaseClass>
        <DomainClassMoniker Name="PipelineNodeBase" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="c89b0445-82ec-428e-87f1-ebc57dcc4f8d" Description="Description for imbNLP.PipelineDSLD.TaskConstructorBase.Name" Name="Name" DisplayName="Name" DefaultValue="" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="f10e850f-9aca-4334-8e73-54f92df24509" Description="Elements embedded in the model. Appear as boxes on the diagram." Name="TestNodeBase" DisplayName="Test Node Base" Namespace="imbNLP.PipelineDSLD">
      <BaseClass>
        <DomainClassMoniker Name="PipelineNodeBase" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="2b9bfc1f-0c97-49bd-a51e-528481b03f9c" Description="Description for imbNLP.PipelineDSLD.TestNodeBase.Name" Name="Name" DisplayName="Name" DefaultValue="" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="6cb12d8c-d13d-418b-b45a-d57708048214" Description="Elements embedded in the model. Appear as boxes on the diagram." Name="TransformNodeBase" DisplayName="Transform Node Base" Namespace="imbNLP.PipelineDSLD">
      <BaseClass>
        <DomainClassMoniker Name="PipelineNodeBase" />
      </BaseClass>
      <Properties>
        <DomainProperty Id="6e1120ce-f2cb-490c-8185-53be93825e0c" Description="Description for imbNLP.PipelineDSLD.TransformNodeBase.Name" Name="Name" DisplayName="Name" DefaultValue="" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="d245752e-8c99-4036-a10e-948156c0c9a1" Description="Description for imbNLP.PipelineDSLD.OutputBinBase" Name="OutputBinBase" DisplayName="Output Bin Base" Namespace="imbNLP.PipelineDSLD" />
    <DomainClass Id="53487580-b096-4ff3-857b-f346c59de6a7" Description="Description for imbNLP.PipelineDSLD.OutputBin" Name="OutputBin" DisplayName="Output Bin" Namespace="imbNLP.PipelineDSLD">
      <BaseClass>
        <DomainClassMoniker Name="OutputBinBase" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="7b7b5854-b7ae-4d29-b442-182f7d7b5f78" Description="Description for imbNLP.PipelineDSLD.TrashBin" Name="TrashBin" DisplayName="Trash Bin" Namespace="imbNLP.PipelineDSLD">
      <BaseClass>
        <DomainClassMoniker Name="OutputBinBase" />
      </BaseClass>
    </DomainClass>
    <DomainClass Id="5978f68a-c8da-4fbf-abff-06a1972dc3c0" Description="Description for imbNLP.PipelineDSLD.PipelineNodeBase" Name="PipelineNodeBase" DisplayName="Pipeline Node Base" Namespace="imbNLP.PipelineDSLD">
      <Properties>
        <DomainProperty Id="5da91299-1f65-4e80-a87a-5b5566fc620f" Description="Description for imbNLP.PipelineDSLD.PipelineNodeBase.Node Name" Name="NodeName" DisplayName="Node Name">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
  </Classes>
  <Relationships>
    <DomainRelationship Id="8a87cb11-625c-42ee-85f4-6616762aa9ed" Description="Description for imbNLP.PipelineDSLD.PipelineNodeBaseReferencesTargetPipelineNodeBases" Name="PipelineNodeBaseReferencesTargetPipelineNodeBases" DisplayName="Pipeline Node Base References Target Pipeline Node Bases" Namespace="imbNLP.PipelineDSLD">
      <Source>
        <DomainRole Id="cd28776c-8ddb-4639-80c1-504aa7834bf1" Description="Description for imbNLP.PipelineDSLD.PipelineNodeBaseReferencesTargetPipelineNodeBases.SourcePipelineNodeBase" Name="SourcePipelineNodeBase" DisplayName="Source Pipeline Node Base" PropertyName="TargetPipelineNodeBases" PropertyDisplayName="Target Pipeline Node Bases">
          <RolePlayer>
            <DomainClassMoniker Name="PipelineNodeBase" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="c21289aa-2749-4b6e-8484-232a7382ca43" Description="Description for imbNLP.PipelineDSLD.PipelineNodeBaseReferencesTargetPipelineNodeBases.TargetPipelineNodeBase" Name="TargetPipelineNodeBase" DisplayName="Target Pipeline Node Base" PropertyName="SourcePipelineNodeBases" PropertyDisplayName="Source Pipeline Node Bases">
          <RolePlayer>
            <DomainClassMoniker Name="PipelineNodeBase" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="6a0518e0-8d2e-463b-b71d-0467b7a6f370" Description="Description for imbNLP.PipelineDSLD.PipelineNodeBaseReferencesOutputBinBases" Name="PipelineNodeBaseReferencesOutputBinBases" DisplayName="Pipeline Node Base References Output Bin Bases" Namespace="imbNLP.PipelineDSLD">
      <Source>
        <DomainRole Id="df7eeae5-d1f4-437e-bd78-2d345d476a37" Description="Description for imbNLP.PipelineDSLD.PipelineNodeBaseReferencesOutputBinBases.PipelineNodeBase" Name="PipelineNodeBase" DisplayName="Pipeline Node Base" PropertyName="OutputBinBases" PropertyDisplayName="Output Bin Bases">
          <RolePlayer>
            <DomainClassMoniker Name="PipelineNodeBase" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="79eb08ba-992b-42df-a150-334c83a44767" Description="Description for imbNLP.PipelineDSLD.PipelineNodeBaseReferencesOutputBinBases.OutputBinBase" Name="OutputBinBase" DisplayName="Output Bin Base" PropertyName="PipelineNodeBases" PropertyDisplayName="Pipeline Node Bases">
          <RolePlayer>
            <DomainClassMoniker Name="OutputBinBase" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="8ba63b03-0700-4950-ade7-ad615920f5bc" Description="Description for imbNLP.PipelineDSLD.PipelineModelHasOutputBinBases" Name="PipelineModelHasOutputBinBases" DisplayName="Pipeline Model Has Output Bin Bases" Namespace="imbNLP.PipelineDSLD" IsEmbedding="true">
      <Source>
        <DomainRole Id="56fdcf70-acd7-45b4-8884-24058268d76b" Description="Description for imbNLP.PipelineDSLD.PipelineModelHasOutputBinBases.PipelineModel" Name="PipelineModel" DisplayName="Pipeline Model" PropertyName="OutputBinBases" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Output Bin Bases">
          <RolePlayer>
            <DomainClassMoniker Name="PipelineModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="d9e08db7-4a0b-47ed-ace5-a2e73adf74f8" Description="Description for imbNLP.PipelineDSLD.PipelineModelHasOutputBinBases.OutputBinBase" Name="OutputBinBase" DisplayName="Output Bin Base" PropertyName="PipelineModel" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Pipeline Model">
          <RolePlayer>
            <DomainClassMoniker Name="OutputBinBase" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="de241811-f893-4d75-9a9b-73672599f006" Description="Description for imbNLP.PipelineDSLD.PipelineModelHasPipelineNodeBases" Name="PipelineModelHasPipelineNodeBases" DisplayName="Pipeline Model Has Pipeline Node Bases" Namespace="imbNLP.PipelineDSLD" IsEmbedding="true">
      <Source>
        <DomainRole Id="2a43c717-7593-4c46-971c-f986e65f517e" Description="Description for imbNLP.PipelineDSLD.PipelineModelHasPipelineNodeBases.PipelineModel" Name="PipelineModel" DisplayName="Pipeline Model" PropertyName="PipelineNodeBases" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Pipeline Node Bases">
          <RolePlayer>
            <DomainClassMoniker Name="PipelineModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="8fdb5ec8-0e19-4443-8bed-633f0739ede5" Description="Description for imbNLP.PipelineDSLD.PipelineModelHasPipelineNodeBases.PipelineNodeBase" Name="PipelineNodeBase" DisplayName="Pipeline Node Base" PropertyName="PipelineModel" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Pipeline Model">
          <RolePlayer>
            <DomainClassMoniker Name="PipelineNodeBase" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
  </Relationships>
  <Types>
    <ExternalType Name="DateTime" Namespace="System" />
    <ExternalType Name="String" Namespace="System" />
    <ExternalType Name="Int16" Namespace="System" />
    <ExternalType Name="Int32" Namespace="System" />
    <ExternalType Name="Int64" Namespace="System" />
    <ExternalType Name="UInt16" Namespace="System" />
    <ExternalType Name="UInt32" Namespace="System" />
    <ExternalType Name="UInt64" Namespace="System" />
    <ExternalType Name="SByte" Namespace="System" />
    <ExternalType Name="Byte" Namespace="System" />
    <ExternalType Name="Double" Namespace="System" />
    <ExternalType Name="Single" Namespace="System" />
    <ExternalType Name="Guid" Namespace="System" />
    <ExternalType Name="Boolean" Namespace="System" />
    <ExternalType Name="Char" Namespace="System" />
  </Types>
  <Shapes>
    <GeometryShape Id="43788c15-e75c-45c2-9fb0-7d0d17cb80ce" Description="Shape used to represent ExampleElements on a Diagram." Name="ExampleShape" DisplayName="Example Shape" Namespace="imbNLP.PipelineDSLD" FixedTooltipText="Example Shape" FillColor="242, 239, 229" OutlineColor="113, 111, 110" InitialWidth="2" InitialHeight="0.75" OutlineThickness="0.01" Geometry="Rectangle">
      <Notes>The shape has a text decorator used to display the Name property of the mapped ExampleElement.</Notes>
      <ShapeHasDecorators Position="Center" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="NameDecorator" DisplayName="Name Decorator" DefaultText="NameDecorator" />
      </ShapeHasDecorators>
    </GeometryShape>
    <GeometryShape Id="3aa47ee3-1867-41ec-a56c-3f9c03764dd3" Description="Shape used to represent ExampleElements on a Diagram." Name="ExampleShape1" DisplayName="Example Shape1" Namespace="imbNLP.PipelineDSLD" FixedTooltipText="Example Shape1" FillColor="242, 239, 229" OutlineColor="113, 111, 110" InitialWidth="2" InitialHeight="0.75" OutlineThickness="0.01" Geometry="Rectangle">
      <Notes>The shape has a text decorator used to display the Name property of the mapped ExampleElement.</Notes>
      <ShapeHasDecorators Position="Center" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="NameDecorator" DisplayName="Name Decorator" DefaultText="NameDecorator" />
      </ShapeHasDecorators>
    </GeometryShape>
    <GeometryShape Id="d6c12479-e1a5-4047-a6a5-9d389909564a" Description="Description for imbNLP.PipelineDSLD.NodeShape" Name="NodeShape" DisplayName="Node Shape" Namespace="imbNLP.PipelineDSLD" FixedTooltipText="Node Shape" InitialHeight="1" Geometry="Rectangle" />
    <GeometryShape Id="58ef503c-f720-4e8e-962e-097c85e79b6c" Description="Description for imbNLP.PipelineDSLD.BinShape" Name="BinShape" DisplayName="Bin Shape" Namespace="imbNLP.PipelineDSLD" FixedTooltipText="Bin Shape" InitialHeight="1" Geometry="Rectangle" />
  </Shapes>
  <Connectors>
    <Connector Id="c6421de6-bec5-497b-b717-4777e92e696b" Description="Connector between the ExampleShapes. Represents ExampleRelationships on the Diagram." Name="Next" DisplayName="Next" Namespace="imbNLP.PipelineDSLD" FixedTooltipText="Next" Color="113, 111, 110" TargetEndStyle="EmptyArrow" Thickness="0.01" />
    <Connector Id="e385cadb-e9d6-4cc9-92e1-be36ee2c4eff" Description="Connector between the ExampleShapes. Represents ExampleRelationships on the Diagram." Name="Forward" DisplayName="Forward" Namespace="imbNLP.PipelineDSLD" FixedTooltipText="Forward" Color="192, 0, 0" DashStyle="Dot" TargetEndStyle="EmptyArrow" Thickness="0.01" />
    <Connector Id="2f8d2921-3885-4a17-a5a3-b264fe107c5a" Description="Description for imbNLP.PipelineDSLD.Connector1" Name="Connector1" DisplayName="Connector1" Namespace="imbNLP.PipelineDSLD" FixedTooltipText="Connector1" />
    <Connector Id="824c46bd-acd5-4910-bf48-956807fa9ae8" Description="Description for imbNLP.PipelineDSLD.Connector2" Name="Connector2" DisplayName="Connector2" Namespace="imbNLP.PipelineDSLD" FixedTooltipText="Connector2" />
  </Connectors>
  <XmlSerializationBehavior Name="NLPPipelineDSLDSerializationBehavior" Namespace="imbNLP.PipelineDSLD">
    <ClassData>
      <XmlClassData TypeName="PipelineModel" MonikerAttributeName="" SerializeId="true" MonikerElementName="pipelineModelMoniker" ElementName="pipelineModel" MonikerTypeName="PipelineModelMoniker">
        <DomainClassMoniker Name="PipelineModel" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="outputBinBases">
            <DomainRelationshipMoniker Name="PipelineModelHasOutputBinBases" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="pipelineNodeBases">
            <DomainRelationshipMoniker Name="PipelineModelHasPipelineNodeBases" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ExampleShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="exampleShapeMoniker" ElementName="exampleShape" MonikerTypeName="ExampleShapeMoniker">
        <GeometryShapeMoniker Name="ExampleShape" />
      </XmlClassData>
      <XmlClassData TypeName="Next" MonikerAttributeName="" SerializeId="true" MonikerElementName="nextMoniker" ElementName="next" MonikerTypeName="NextMoniker">
        <ConnectorMoniker Name="Next" />
      </XmlClassData>
      <XmlClassData TypeName="NLPPipelineDSLDDiagram" MonikerAttributeName="" SerializeId="true" MonikerElementName="nLPPipelineDSLDDiagramMoniker" ElementName="nLPPipelineDSLDDiagram" MonikerTypeName="NLPPipelineDSLDDiagramMoniker">
        <DiagramMoniker Name="NLPPipelineDSLDDiagram" />
        <ElementData>
          <XmlPropertyData XmlName="modelName">
            <DomainPropertyMoniker Name="NLPPipelineDSLDDiagram/ModelName" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="Forward" MonikerAttributeName="" SerializeId="true" MonikerElementName="forwardMoniker" ElementName="forward" MonikerTypeName="ForwardMoniker">
        <ConnectorMoniker Name="Forward" />
      </XmlClassData>
      <XmlClassData TypeName="TaskConstructorBase" MonikerAttributeName="" SerializeId="true" MonikerElementName="taskConstructorBaseMoniker" ElementName="taskConstructorBase" MonikerTypeName="TaskConstructorBaseMoniker">
        <DomainClassMoniker Name="TaskConstructorBase" />
        <ElementData>
          <XmlPropertyData XmlName="name">
            <DomainPropertyMoniker Name="TaskConstructorBase/Name" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="TestNodeBase" MonikerAttributeName="" SerializeId="true" MonikerElementName="testNodeBaseMoniker" ElementName="testNodeBase" MonikerTypeName="TestNodeBaseMoniker">
        <DomainClassMoniker Name="TestNodeBase" />
        <ElementData>
          <XmlPropertyData XmlName="name">
            <DomainPropertyMoniker Name="TestNodeBase/Name" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="ExampleShape1" MonikerAttributeName="" SerializeId="true" MonikerElementName="exampleShape1Moniker" ElementName="exampleShape1" MonikerTypeName="ExampleShape1Moniker">
        <GeometryShapeMoniker Name="ExampleShape1" />
      </XmlClassData>
      <XmlClassData TypeName="NodeShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="nodeShapeMoniker" ElementName="nodeShape" MonikerTypeName="NodeShapeMoniker">
        <GeometryShapeMoniker Name="NodeShape" />
      </XmlClassData>
      <XmlClassData TypeName="TransformNodeBase" MonikerAttributeName="" SerializeId="true" MonikerElementName="transformNodeBaseMoniker" ElementName="transformNodeBase" MonikerTypeName="TransformNodeBaseMoniker">
        <DomainClassMoniker Name="TransformNodeBase" />
        <ElementData>
          <XmlPropertyData XmlName="name">
            <DomainPropertyMoniker Name="TransformNodeBase/Name" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="OutputBinBase" MonikerAttributeName="" SerializeId="true" MonikerElementName="outputBinBaseMoniker" ElementName="outputBinBase" MonikerTypeName="OutputBinBaseMoniker">
        <DomainClassMoniker Name="OutputBinBase" />
      </XmlClassData>
      <XmlClassData TypeName="OutputBin" MonikerAttributeName="" SerializeId="true" MonikerElementName="outputBinMoniker" ElementName="outputBin" MonikerTypeName="OutputBinMoniker">
        <DomainClassMoniker Name="OutputBin" />
      </XmlClassData>
      <XmlClassData TypeName="TrashBin" MonikerAttributeName="" SerializeId="true" MonikerElementName="trashBinMoniker" ElementName="trashBin" MonikerTypeName="TrashBinMoniker">
        <DomainClassMoniker Name="TrashBin" />
      </XmlClassData>
      <XmlClassData TypeName="BinShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="binShapeMoniker" ElementName="binShape" MonikerTypeName="BinShapeMoniker">
        <GeometryShapeMoniker Name="BinShape" />
      </XmlClassData>
      <XmlClassData TypeName="Connector1" MonikerAttributeName="" SerializeId="true" MonikerElementName="connector1Moniker" ElementName="connector1" MonikerTypeName="Connector1Moniker">
        <ConnectorMoniker Name="Connector1" />
      </XmlClassData>
      <XmlClassData TypeName="Connector2" MonikerAttributeName="" SerializeId="true" MonikerElementName="connector2Moniker" ElementName="connector2" MonikerTypeName="Connector2Moniker">
        <ConnectorMoniker Name="Connector2" />
      </XmlClassData>
      <XmlClassData TypeName="PipelineNodeBase" MonikerAttributeName="" SerializeId="true" MonikerElementName="pipelineNodeBaseMoniker" ElementName="pipelineNodeBase" MonikerTypeName="PipelineNodeBaseMoniker">
        <DomainClassMoniker Name="PipelineNodeBase" />
        <ElementData>
          <XmlPropertyData XmlName="nodeName">
            <DomainPropertyMoniker Name="PipelineNodeBase/NodeName" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="targetPipelineNodeBases">
            <DomainRelationshipMoniker Name="PipelineNodeBaseReferencesTargetPipelineNodeBases" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="outputBinBases">
            <DomainRelationshipMoniker Name="PipelineNodeBaseReferencesOutputBinBases" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="PipelineNodeBaseReferencesTargetPipelineNodeBases" MonikerAttributeName="" SerializeId="true" MonikerElementName="pipelineNodeBaseReferencesTargetPipelineNodeBasesMoniker" ElementName="pipelineNodeBaseReferencesTargetPipelineNodeBases" MonikerTypeName="PipelineNodeBaseReferencesTargetPipelineNodeBasesMoniker">
        <DomainRelationshipMoniker Name="PipelineNodeBaseReferencesTargetPipelineNodeBases" />
      </XmlClassData>
      <XmlClassData TypeName="PipelineNodeBaseReferencesOutputBinBases" MonikerAttributeName="" SerializeId="true" MonikerElementName="pipelineNodeBaseReferencesOutputBinBasesMoniker" ElementName="pipelineNodeBaseReferencesOutputBinBases" MonikerTypeName="PipelineNodeBaseReferencesOutputBinBasesMoniker">
        <DomainRelationshipMoniker Name="PipelineNodeBaseReferencesOutputBinBases" />
      </XmlClassData>
      <XmlClassData TypeName="PipelineModelHasOutputBinBases" MonikerAttributeName="" SerializeId="true" MonikerElementName="pipelineModelHasOutputBinBasesMoniker" ElementName="pipelineModelHasOutputBinBases" MonikerTypeName="PipelineModelHasOutputBinBasesMoniker">
        <DomainRelationshipMoniker Name="PipelineModelHasOutputBinBases" />
      </XmlClassData>
      <XmlClassData TypeName="PipelineModelHasPipelineNodeBases" MonikerAttributeName="" SerializeId="true" MonikerElementName="pipelineModelHasPipelineNodeBasesMoniker" ElementName="pipelineModelHasPipelineNodeBases" MonikerTypeName="PipelineModelHasPipelineNodeBasesMoniker">
        <DomainRelationshipMoniker Name="PipelineModelHasPipelineNodeBases" />
      </XmlClassData>
    </ClassData>
  </XmlSerializationBehavior>
  <ExplorerBehavior Name="NLPPipelineDSLDExplorer" />
  <ConnectionBuilders>
    <ConnectionBuilder Name="PipelineNodeBaseReferencesTargetPipelineNodeBasesBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="PipelineNodeBaseReferencesTargetPipelineNodeBases" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="PipelineNodeBase" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="PipelineNodeBase" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="PipelineNodeBaseReferencesOutputBinBasesBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="PipelineNodeBaseReferencesOutputBinBases" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="PipelineNodeBase" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="OutputBinBase" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
  </ConnectionBuilders>
  <Diagram Id="02d97e3b-4695-4581-ad8d-adc22b633e5f" Description="Model of content processing pipeline" Name="NLPPipelineDSLDDiagram" DisplayName="Pipeline Model" Namespace="imbNLP.PipelineDSLD">
    <Properties>
      <DomainProperty Id="f698351d-9423-466e-b63a-c0518272253a" Description="Description for imbNLP.PipelineDSLD.NLPPipelineDSLDDiagram.Model Name" Name="ModelName" DisplayName="Model Name">
        <Type>
          <ExternalTypeMoniker Name="/System/String" />
        </Type>
      </DomainProperty>
    </Properties>
    <Class>
      <DomainClassMoniker Name="PipelineModel" />
    </Class>
    <ShapeMaps>
      <ShapeMap>
        <DomainClassMoniker Name="OutputBinBase" />
        <ParentElementPath>
          <DomainPath />
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="ExampleShape1/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath />
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="ExampleShape1" />
      </ShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="PipelineNodeBase" />
        <ParentElementPath>
          <DomainPath>PipelineModelHasPipelineNodeBases.PipelineModel/!PipelineModel</DomainPath>
        </ParentElementPath>
        <GeometryShapeMoniker Name="NodeShape" />
      </ShapeMap>
    </ShapeMaps>
  </Diagram>
  <Designer CopyPasteGeneration="CopyPasteOnly" FileExtension="imbNLPPipelineDSLD" EditorGuid="e16bcfed-eb3d-41d0-bf57-743bed0804eb">
    <RootClass>
      <DomainClassMoniker Name="PipelineModel" />
    </RootClass>
    <XmlSerializationDefinition CustomPostLoad="false">
      <XmlSerializationBehaviorMoniker Name="NLPPipelineDSLDSerializationBehavior" />
    </XmlSerializationDefinition>
    <ToolboxTab TabText="NLPPipelineDSLD">
      <ElementTool Name="ExampleElement" ToolboxIcon="resources\exampleshapetoolbitmap.bmp" Caption="ExampleElement" Tooltip="Create an ExampleElement" HelpKeyword="CreateExampleClassF1Keyword">
        <DomainClassMoniker Name="TaskConstructorBase" />
      </ElementTool>
      <ConnectionTool Name="ExampleRelationship" ToolboxIcon="resources\exampleconnectortoolbitmap.bmp" Caption="ExampleRelationship" Tooltip="Drag between ExampleElements to create an ExampleRelationship" HelpKeyword="ConnectExampleRelationF1Keyword" />
    </ToolboxTab>
    <Validation UsesMenu="false" UsesOpen="false" UsesSave="false" UsesLoad="false" />
    <DiagramMoniker Name="NLPPipelineDSLDDiagram" />
  </Designer>
  <Explorer ExplorerGuid="4f7870a6-1bed-41c1-9824-a9737fb32b29" Title="NLPPipelineDSLD Explorer">
    <ExplorerBehaviorMoniker Name="NLPPipelineDSLD/NLPPipelineDSLDExplorer" />
  </Explorer>
</Dsl>
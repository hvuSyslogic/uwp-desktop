using Microsoft.CodeAnalysis;
using System.Collections.Generic;

public class UwpDesktopAnalyzer
{
    public static DiagnosticDescriptor Rule = new DiagnosticDescriptor("UWP003", "UWP-only", "Type '{0}' can only be used in UWP apps, not Desktop or Centennial", "Safety", DiagnosticSeverity.Warning, true);

    private static HashSet<string> _forbiddenTypes;

    public static HashSet<string> ForbiddenTypes
    {
        get
        {
            if (_forbiddenTypes != null) return _forbiddenTypes;
            _forbiddenTypes = new HashSet<string>()
            {
                "Windows.ApplicationModel.Resources.Management.IndexedResourceCandidate",
                "Windows.ApplicationModel.Resources.Management.IndexedResourceQualifier",
                "Windows.ApplicationModel.Resources.Management.ResourceIndexer",
                "Windows.ApplicationModel.SocialInfo.Provider.SocialDashboardItemUpdater",
                "Windows.ApplicationModel.SocialInfo.Provider.SocialFeedUpdater",
                "Windows.ApplicationModel.SocialInfo.Provider.SocialInfoProviderManager",
                "Windows.ApplicationModel.SocialInfo.SocialFeedChildItem",
                "Windows.ApplicationModel.SocialInfo.SocialFeedContent",
                "Windows.ApplicationModel.SocialInfo.SocialFeedItem",
                "Windows.ApplicationModel.SocialInfo.SocialFeedSharedItem",
                "Windows.ApplicationModel.SocialInfo.SocialItemThumbnail",
                "Windows.ApplicationModel.SocialInfo.SocialUserInfo",
                "Windows.ApplicationModel.Store.CurrentApp",
                "Windows.ApplicationModel.Store.CurrentAppSimulator",
                "Windows.ApplicationModel.Store.LicenseChangedEventHandler",
                "Windows.ApplicationModel.Store.LicenseInformation",
                "Windows.ApplicationModel.Store.LicenseManagement.LicenseManager",
                "Windows.ApplicationModel.Store.ListingInformation",
                "Windows.ApplicationModel.Store.ProductLicense",
                "Windows.ApplicationModel.Store.ProductListing",
                "Windows.ApplicationModel.Store.ProductPurchaseDisplayProperties",
                "Windows.ApplicationModel.Store.PurchaseResults",
                "Windows.ApplicationModel.Store.UnfulfilledConsumable",
                "Windows.ApplicationModel.UserDataAccounts.SystemAccess.DeviceAccountConfiguration",
                "Windows.ApplicationModel.UserDataAccounts.SystemAccess.UserDataAccountSystemAccessManager",
                "Windows.ApplicationModel.UserDataAccounts.UserDataAccount",
                "Windows.ApplicationModel.UserDataAccounts.UserDataAccountManager",
                "Windows.ApplicationModel.UserDataAccounts.UserDataAccountManagerForUser",
                "Windows.ApplicationModel.UserDataAccounts.UserDataAccountStore",
                "Windows.ApplicationModel.UserDataAccounts.UserDataAccountStoreChangedEventArgs",
                "Windows.Devices.Custom.KnownDeviceTypes",
                "Windows.Devices.Enumeration.DeviceAccessInformation",
                "Windows.Devices.Geolocation.Geofencing.Geofence",
                "Windows.Devices.Geolocation.Geofencing.GeofenceMonitor",
                "Windows.Devices.Geolocation.Geofencing.GeofenceStateChangeReport",
                "Windows.Devices.SmartCards.CardAddedEventArgs",
                "Windows.Devices.SmartCards.CardRemovedEventArgs",
                "Windows.Devices.SmartCards.SmartCardChallengeContext",
                "Windows.Devices.SmartCards.SmartCardPinPolicy",
                "Windows.Devices.SmartCards.SmartCardPinResetDeferral",
                "Windows.Devices.SmartCards.SmartCardPinResetHandler",
                "Windows.Devices.SmartCards.SmartCardPinResetRequest",
                "Windows.Devices.SmartCards.SmartCardProvisioning",
                "Windows.Foundation.Diagnostics.AsyncCausalityTracer",
                "Windows.Foundation.Diagnostics.ErrorDetails",
                "Windows.Foundation.Diagnostics.RuntimeBrokerErrorSettings",
                "Windows.Foundation.Diagnostics.TracingStatusChangedEventArgs",
                "Windows.Graphics.Display.DisplayInformation",
                "Windows.Graphics.Printing.OptionDetails.PrintBindingOptionDetails",
                "Windows.Graphics.Printing.OptionDetails.PrintBorderingOptionDetails",
                "Windows.Graphics.Printing.OptionDetails.PrintCollationOptionDetails",
                "Windows.Graphics.Printing.OptionDetails.PrintColorModeOptionDetails",
                "Windows.Graphics.Printing.OptionDetails.PrintCopiesOptionDetails",
                "Windows.Graphics.Printing.OptionDetails.PrintCustomItemDetails",
                "Windows.Graphics.Printing.OptionDetails.PrintCustomItemListOptionDetails",
                "Windows.Graphics.Printing.OptionDetails.PrintCustomTextOptionDetails",
                "Windows.Graphics.Printing.OptionDetails.PrintDuplexOptionDetails",
                "Windows.Graphics.Printing.OptionDetails.PrintHolePunchOptionDetails",
                "Windows.Graphics.Printing.OptionDetails.PrintMediaSizeOptionDetails",
                "Windows.Graphics.Printing.OptionDetails.PrintMediaTypeOptionDetails",
                "Windows.Graphics.Printing.OptionDetails.PrintOrientationOptionDetails",
                "Windows.Graphics.Printing.OptionDetails.PrintQualityOptionDetails",
                "Windows.Graphics.Printing.OptionDetails.PrintStapleOptionDetails",
                "Windows.Graphics.Printing.OptionDetails.PrintTaskOptionChangedEventArgs",
                "Windows.Graphics.Printing.OptionDetails.PrintTaskOptionDetails",
                "Windows.Graphics.Printing.PrintManager",
                "Windows.Graphics.Printing.PrintTask",
                "Windows.Graphics.Printing.PrintTaskCompletedEventArgs",
                "Windows.Graphics.Printing.PrintTaskOptions",
                "Windows.Graphics.Printing.PrintTaskProgressingEventArgs",
                "Windows.Graphics.Printing.PrintTaskRequest",
                "Windows.Graphics.Printing.PrintTaskRequestedDeferral",
                "Windows.Graphics.Printing.PrintTaskRequestedEventArgs",
                "Windows.Graphics.Printing.PrintTaskSourceRequestedArgs",
                "Windows.Graphics.Printing.StandardPrintTaskOptions",
                "Windows.Management.Orchestration.CurrentAppOrchestration",
                "Windows.Management.Orchestration.SingleAppModeContext",
                "Windows.Media.ContentRestrictions.ContentRestrictionsBrowsePolicy",
                "Windows.Media.ContentRestrictions.RatedContentDescription",
                "Windows.Media.ContentRestrictions.RatedContentRestrictions",
                "Windows.Media.Effects.AudioCaptureEffectsManager",
                "Windows.Media.Effects.AudioEffectsManager",
                "Windows.Media.Effects.AudioRenderEffectsManager",
                "Windows.Media.Effects.CompositeVideoFrameContext",
                "Windows.Media.Effects.ProcessVideoFrameContext",
                "Windows.Networking.Proximity.ConnectionRequestedEventArgs",
                "Windows.Networking.Proximity.DeviceArrivedEventHandler",
                "Windows.Networking.Proximity.DeviceDepartedEventHandler",
                "Windows.Networking.Proximity.MessageReceivedHandler",
                "Windows.Networking.Proximity.MessageTransmittedHandler",
                "Windows.Networking.Proximity.PeerFinder",
                "Windows.Networking.Proximity.PeerInformation",
                "Windows.Networking.Proximity.PeerWatcher",
                "Windows.Networking.Proximity.TriggeredConnectionStateChangedEventArgs",
                "Windows.Networking.PushNotifications.PushNotificationChannelManagerForUser",
                "Windows.Networking.Vpn.VpnAppId",
                "Windows.Networking.Vpn.VpnChannel",
                "Windows.Networking.Vpn.VpnChannelActivityEventArgs",
                "Windows.Networking.Vpn.VpnChannelActivityStateChangedArgs",
                "Windows.Networking.Vpn.VpnChannelConfiguration",
                "Windows.Networking.Vpn.VpnCredential",
                "Windows.Networking.Vpn.VpnCustomCheckBox",
                "Windows.Networking.Vpn.VpnCustomComboBox",
                "Windows.Networking.Vpn.VpnCustomEditBox",
                "Windows.Networking.Vpn.VpnCustomErrorBox",
                "Windows.Networking.Vpn.VpnCustomPromptBooleanInput",
                "Windows.Networking.Vpn.VpnCustomPromptOptionSelector",
                "Windows.Networking.Vpn.VpnCustomPromptText",
                "Windows.Networking.Vpn.VpnCustomPromptTextInput",
                "Windows.Networking.Vpn.VpnCustomTextBox",
                "Windows.Networking.Vpn.VpnDomainNameAssignment",
                "Windows.Networking.Vpn.VpnDomainNameInfo",
                "Windows.Networking.Vpn.VpnInterfaceId",
                "Windows.Networking.Vpn.VpnManagementAgent",
                "Windows.Networking.Vpn.VpnNamespaceAssignment",
                "Windows.Networking.Vpn.VpnNamespaceInfo",
                "Windows.Networking.Vpn.VpnNativeProfile",
                "Windows.Networking.Vpn.VpnPacketBuffer",
                "Windows.Networking.Vpn.VpnPacketBufferList",
                "Windows.Networking.Vpn.VpnPickedCredential",
                "Windows.Networking.Vpn.VpnPlugInProfile",
                "Windows.Networking.Vpn.VpnRoute",
                "Windows.Networking.Vpn.VpnRouteAssignment",
                "Windows.Networking.Vpn.VpnSystemHealth",
                "Windows.Networking.Vpn.VpnTrafficFilter",
                "Windows.Networking.Vpn.VpnTrafficFilterAssignment",
                "Windows.Storage.Search.ContentIndexer",
                "Windows.Storage.Search.ContentIndexerQuery",
                "Windows.Storage.Search.IndexableContent",
                "Windows.Storage.Search.QueryOptions",
                "Windows.Storage.Search.SortEntryVector",
                "Windows.Storage.Search.StorageFileQueryResult",
                "Windows.Storage.Search.StorageFolderQueryResult",
                "Windows.Storage.Search.StorageItemQueryResult",
                "Windows.Storage.Search.ValueAndLanguage",
                "Windows.System.AppMemoryReport",
                "Windows.System.AppMemoryUsageLimitChangingEventArgs",
                "Windows.System.FolderLauncherOptions",
                "Windows.System.Launcher",
                "Windows.System.LauncherOptions",
                "Windows.System.LauncherUIOptions",
                "Windows.System.LaunchUriResult",
                "Windows.System.MemoryManager",
                "Windows.System.Power.BackgroundEnergyManager",
                "Windows.System.Power.Diagnostics.BackgroundEnergyDiagnostics",
                "Windows.System.Power.Diagnostics.ForegroundEnergyDiagnostics",
                "Windows.System.Power.ForegroundEnergyManager",
                "Windows.System.Power.PowerManager",
                "Windows.System.ProcessMemoryReport",
                "Windows.System.ProtocolForResultsOperation",
                "Windows.System.RemoteLauncher",
                "Windows.System.RemoteLauncherOptions",
                "Windows.System.RemoteSystems.RemoteSystem",
                "Windows.System.RemoteSystems.RemoteSystemAddedEventArgs",
                "Windows.System.RemoteSystems.RemoteSystemConnectionRequest",
                "Windows.System.RemoteSystems.RemoteSystemDiscoveryTypeFilter",
                "Windows.System.RemoteSystems.RemoteSystemKindFilter",
                "Windows.System.RemoteSystems.RemoteSystemKinds",
                "Windows.System.RemoteSystems.RemoteSystemRemovedEventArgs",
                "Windows.System.RemoteSystems.RemoteSystemStatusTypeFilter",
                "Windows.System.RemoteSystems.RemoteSystemUpdatedEventArgs",
                "Windows.System.RemoteSystems.RemoteSystemWatcher",
                "Windows.UI.Notifications.AdaptiveNotificationText",
                "Windows.UI.Notifications.BadgeUpdateManagerForUser",
                "Windows.UI.Notifications.KnownAdaptiveNotificationHints",
                "Windows.UI.Notifications.KnownAdaptiveNotificationTextStyles",
                "Windows.UI.Notifications.KnownNotificationBindings",
                "Windows.UI.Notifications.Management.UserNotificationListener",
                "Windows.UI.Notifications.Notification",
                "Windows.UI.Notifications.NotificationBinding",
                "Windows.UI.Notifications.NotificationVisual",
                "Windows.UI.Notifications.ShownTileNotification",
                "Windows.UI.Notifications.TileFlyoutNotification",
                "Windows.UI.Notifications.TileFlyoutUpdateManager",
                "Windows.UI.Notifications.TileFlyoutUpdater",
                "Windows.UI.Notifications.TileUpdateManagerForUser",
                "Windows.UI.Notifications.ToastNotificationActionTriggerDetail",
                "Windows.UI.Notifications.ToastNotificationHistoryChangedTriggerDetail",
                "Windows.UI.Notifications.ToastNotificationManagerForUser",
                "Windows.UI.Notifications.UserNotification",
                "Windows.UI.Notifications.UserNotificationChangedEventArgs",
                "Windows.UI.Text.FontWeights",
                "Windows.UI.Text.TextConstants",
                "Windows.Web.Http.Diagnostics.HttpDiagnosticProvider",
                "Windows.Web.Http.Diagnostics.HttpDiagnosticProviderRequestResponseCompletedEventArgs",
                "Windows.Web.Http.Diagnostics.HttpDiagnosticProviderRequestResponseTimestamps",
                "Windows.Web.Http.Diagnostics.HttpDiagnosticProviderRequestSentEventArgs",
                "Windows.Web.Http.Diagnostics.HttpDiagnosticProviderResponseReceivedEventArgs",
                "Windows.Web.Http.Diagnostics.HttpDiagnosticSourceLocation"
            };
            return _forbiddenTypes;
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Collections.Immutable;
//using System.Linq;
//using System.Threading;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.CSharp;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using Microsoft.CodeAnalysis.Diagnostics;

//namespace UwpDesktopAnalyzer
//{
//    [DiagnosticAnalyzer(LanguageNames.CSharp)]
//    public class UwpDesktopAnalyzerAnalyzer : DiagnosticAnalyzer
//    {
//        public const string DiagnosticId = "UwpDesktopAnalyzer";

//        // You can change these strings in the Resources.resx file. If you do not want your analyzer to be localize-able, you can use regular strings for Title and MessageFormat.
//        // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Localizing%20Analyzers.md for more on localization
//        private static readonly LocalizableString Title = new LocalizableResourceString(nameof(Resources.AnalyzerTitle), Resources.ResourceManager, typeof(Resources));
//        private static readonly LocalizableString MessageFormat = new LocalizableResourceString(nameof(Resources.AnalyzerMessageFormat), Resources.ResourceManager, typeof(Resources));
//        private static readonly LocalizableString Description = new LocalizableResourceString(nameof(Resources.AnalyzerDescription), Resources.ResourceManager, typeof(Resources));
//        private const string Category = "Naming";

//        private static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

//        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

//        public override void Initialize(AnalysisContext context)
//        {
//            // TODO: Consider registering other actions that act on syntax instead of or in addition to symbols
//            // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Analyzer%20Actions%20Semantics.md for more information
//            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.NamedType);
//        }

//        private static void AnalyzeSymbol(SymbolAnalysisContext context)
//        {
//            // TODO: Replace the following code with your own analysis, generating Diagnostic objects for any issues you find
//            var namedTypeSymbol = (INamedTypeSymbol)context.Symbol;

//            // Find just those named type symbols with names containing lowercase letters.
//            if (namedTypeSymbol.Name.ToCharArray().Any(char.IsLower))
//            {
//                // For all such symbols, produce a diagnostic.
//                var diagnostic = Diagnostic.Create(Rule, namedTypeSymbol.Locations[0], namedTypeSymbol.Name);

//                context.ReportDiagnostic(diagnostic);
//            }
//        }
//    }
//}
using System;
using System.Data;
using System.Linq;
using System.Data.Entity;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.ComponentModel;
using DevExpress.ExpressApp.EF.Updating;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.ExpressApp.Workflow.EF;
using DevExpress.ExpressApp.Workflow.Versioning;
using DevExpress.Workflow.EF;

namespace Yonetım.Module.BusinessObjects {
	public class YonetımDbContext : DbContext {
		public YonetımDbContext(String connectionString)
			: base(connectionString) {
		}
		public YonetımDbContext(DbConnection connection)
			: base(connection, false) {
		}
		public YonetımDbContext()
			: base("name=ConnectionString") {
		}
		public DbSet<ModuleInfo> ModulesInfo { get; set; }
	    public DbSet<PermissionPolicyRole> Roles { get; set; }
		public DbSet<PermissionPolicyTypePermissionObject> TypePermissionObjects { get; set; }
		public DbSet<PermissionPolicyUser> Users { get; set; }
		public DbSet<FileData> FileData { get; set; }
		public DbSet<DashboardData> DashboardData { get; set; }
		public DbSet<ReportDataV2> ReportDataV2 { get; set; }
		public DbSet<ModelDifference> ModelDifferences { get; set; }
		public DbSet<ModelDifferenceAspect> ModelDifferenceAspects { get; set; }
		public DbSet<EFWorkflowDefinition> EFWorkflowDefinition { get; set; }
        public DbSet<EFStartWorkflowRequest> EFStartWorkflowRequest { get; set; }
        public DbSet<EFRunningWorkflowInstanceInfo> EFRunningWorkflowInstanceInfo { get; set; }
        public DbSet<EFWorkflowInstanceControlCommandRequest> EFWorkflowInstanceControlCommandRequest { get; set; }
        public DbSet<EFInstanceKey> EFInstanceKey { get; set; }
        public DbSet<EFTrackingRecord> EFTrackingRecord { get; set; }
        public DbSet<EFWorkflowInstance> EFWorkflowInstance { get; set; }
        public DbSet<EFUserActivityVersion> EFUserActivityVersion { get; set; }
	}
}